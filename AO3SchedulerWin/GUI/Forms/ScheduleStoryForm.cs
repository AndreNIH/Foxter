using System.Linq;
using AO3SchedulerWin.Controllers.StoryControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AO3SchedulerWin.AO3;
using AO3SchedulerWin.BEmu;
using System.IO;
using AO3SchedulerWin.Models.Base;
using log4net;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Controllers.ChapterControllers;
using System.Diagnostics;

namespace AO3SchedulerWin.Forms
{
    public partial class ScheduleStoryForm : Form
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Ao3Client _client;
        private IChapterController _controller;
        public ScheduleStoryForm(IChapterModel model, Ao3Client client)
        {
            InitializeComponent();
            mainContainer.Appearance = TabAppearance.FlatButtons;
            mainContainer.ItemSize = new Size(0, 1);
            mainContainer.SizeMode = TabSizeMode.Fixed;
            _client = client;
            _controller = new NewChapterController(
                model,
                _client,
                this,
                openInAo3Button,
                worksComboBox,
                chapterComboBox,
                publishingDatePicker,
                scheduleButton,
                deleteButton
             );
        }



        private void deleteButton_Click(object sender, EventArgs e)
        {

        }



        private async void ScheduleStoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                await _controller.InitUI();
                mainContainer.SelectedIndex++;

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Request Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                Close();
            }
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {

        }

        private void openInAo3Button_Click(object sender, EventArgs e)
        {
        }
    }




    public abstract class BaseSchedulerBehavior
    {
        public class Ao3WebResource
        {
            public string DisplayName { get; set; }
            public int Id { get; set; }
            public Ao3WebResource(string displayName, int id)
            {
                DisplayName = displayName;
                Id = id;
            }
        }
        //Data sources
        private List<Ao3WebResource> _storyWebResourceList = new List<Ao3WebResource>();
        private List<Ao3WebResource> _chapterWebResourceList = new List<Ao3WebResource>();

        //Attributes
        public Form targetForm { protected get; set; }
        public ComboBox storyBox { protected get; set; }
        public ComboBox chapterBox { protected get; set; }
        public Button scheduleButton { protected get; set; }
        public Button deleteButton { protected get; set; }
        public DateTimePicker datePicker { protected get; set; }

        //Template methods
        protected abstract Task<List<Ao3WebResource>> FetchStories();
        protected abstract Task<List<Ao3WebResource>> FetchChapters();
        protected abstract Task OnSchedulePost();
        protected abstract Task OnDeletePost();
        protected abstract void AfterPopulateViews();
        public async Task PopulateViews()
        {
            //Data Binding
            storyBox.ValueMember = "Id";
            chapterBox.ValueMember = "Id";
            storyBox.DisplayMember = "DisplayName";
            chapterBox.DisplayMember = "DisplayName";

            //Events
            storyBox.SelectedIndexChanged += StoryBox_SelectedIndexChanged;
            scheduleButton.Click += ScheduleButton_Click;
            deleteButton.Click += DeleteButton_Click;
            //Populate views
            _storyWebResourceList.Clear();
            _chapterWebResourceList.Clear();
            var stories = await FetchStories();
            stories.ForEach(s => _storyWebResourceList.Add(s));
            storyBox.DataSource = _storyWebResourceList;
            chapterBox.DataSource = _chapterWebResourceList;

        }

        private async void DeleteButton_Click(object? sender, EventArgs e)
        {
            await OnDeletePost();
        }

        private async void ScheduleButton_Click(object? sender, EventArgs e)
        {
            await OnSchedulePost();
        }

        private async void StoryBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            _chapterWebResourceList.Clear();
            var chapters = await FetchChapters();
            chapters.ForEach(c => _chapterWebResourceList.Add(c));

            //This is a stupid hack
            chapterBox.DataSource = null;
            chapterBox.ValueMember = "Id";
            chapterBox.DisplayMember = "DisplayName";
            chapterBox.DataSource = _chapterWebResourceList;

            if (chapterBox.SelectedItem == null && chapters.Count > 0)
            {
                chapterBox.SelectedIndex = 0;
            }
        }
    }


    public class ScheduleNewStoryBehavior : BaseSchedulerBehavior
    {
        private Ao3Client _client;
        private IChapterController _controller;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected override async Task<List<Ao3WebResource>> FetchStories()
        {
            var stories = await _client.GetAllWorks();
            return stories.Select(story => new Ao3WebResource(story.WorkTitle, story.WorkId)).ToList();
        }

        protected override async Task<List<Ao3WebResource>> FetchChapters()
        {
            try
            {
                var chapters = await _client.GetChaptersForWork((int)storyBox.SelectedValue);
                return chapters.Where(chapter => chapter.Draft).Select(chapter => new Ao3WebResource(chapter.Title, chapter.Id)).ToList();
            }
            catch (HttpRequestException ex)
            {
                _logger.Warn(ex.Message);
                return new List<Ao3WebResource>();
            }
        }

        protected override void AfterPopulateViews()
        {
            deleteButton.Visible = false;
        }

        //Event handlers
        protected override async Task OnSchedulePost()
        {
            if (chapterBox.SelectedValue != null)
            {
                var newChapter = new Chapter();
                newChapter.StoryTitle = storyBox.Text;
                newChapter.ChapterTitle = chapterBox.Text;
                newChapter.StoryId = (int)storyBox.SelectedValue;
                newChapter.ChapterId = (int)chapterBox.SelectedValue;
                newChapter.PublishingDate = datePicker.Value;
                if (await _controller.Create(newChapter) == false)
                {
                    MessageBox.Show(
                        $"Upload task for '{chapterBox.Text}' couldn't be created",
                        "Scheduling failed.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                      );
                }
                targetForm.Close();
            }
            else
            {
                MessageBox.Show(
                    "You must select a chapter to continue",
                    "Action not allowed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                  );
            }
        }

        protected override async Task OnDeletePost()
        {

        }



        public ScheduleNewStoryBehavior(Ao3Client client, IChapterModel model)
        {
            _client = client;

        }
    }


}
