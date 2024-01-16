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

namespace AO3SchedulerWin.Forms
{
    public partial class ScheduleStoryForm : Form
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IChapterController _storyController;
        private Ao3Client _session;
        private List<Ao3Work> _works = new List<Ao3Work>();
        private List<int> _workIndexToIdVec = new List<int>();
        private bool _updatePost = false;
        private int? _preloadId = null;
        public ScheduleStoryForm(Ao3Client session, int? preloadId = null)
        {
            InitializeComponent();
            _session = session;
            mainContainer.Appearance = TabAppearance.FlatButtons;
            mainContainer.ItemSize = new Size(0, 1);
            mainContainer.SizeMode = TabSizeMode.Fixed;
            _updatePost = preloadId.HasValue;
        }

        private async Task<bool> LoadAllAuthorStories()
        {
            /*var workEnumerable = await _session.GetAllAuthorWorks();
            _works = workEnumerable.ToList();
            if (_works != null)
            {
                foreach (Ao3Work work in _works)
                {
                    worksComboBox.Items.Add(work.WorkTitle);
                    _workIndexToIdVec.Add(work.WorkId);
                }
            }*/
            return true;

        }

        private async Task<bool> LoadOneStory(int workId)
        {
            /*var work = await Ao3Work.GetWorkFromId(_session, workId);
            worksComboBox.Items.Add(work.WorkTitle);
            _workIndexToIdVec.Add(work.WorkId);*/
            return true;
        }

        //Form Load 
        protected async override void OnLoad(EventArgs e)
        {
            try
            {
                if (_updatePost)
                {
                    deleteButton.Visible = true;
                    _logger.Info($"Updating scheduled post(internal id={_preloadId}). Skipped AO3 Work fetch cycle. Retrieving single story");
                }
                else
                {
                    _logger.Info("Fetching Works from AO3");
                    if (await LoadAllAuthorStories())
                    {
                        mainContainer.SelectedIndex = 1;
                        return;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show(
                     ex.Message,
                    "HTTP Request Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
            catch (Ao3NotFoundException ex)
            {
                _logger.Error(ex.Message);
                if (_updatePost)
                {
                    var res = MessageBox.Show(
                       "The story you want to update no longer exists in Archive Of Our Own.\n\r" +
                       "Do you want to remove it from the application's update list? This action cannot be undone",
                       "Delete missing story",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Warning);
                    if (res == DialogResult.Yes)
                    {
                        
                    }
                }

            }

            Close();
        }
        // File load


        //Form Events
        private void detailsNextButton_Click(object sender, EventArgs e)
        {
            mainContainer.SelectedIndex += 1;
        }

        private async void convertFixNextButton_Click(object sender, EventArgs e)
        {
            var filepath = filePathTextbox.Text;
            if (File.Exists(filepath))
            {
                string? convertedPath = FicConverter.ConvertStory(filepath);
                if (convertedPath == null)
                {
                    MessageBox.Show(
                        $"Failed to convert '{filepath}'",
                        "Convertion Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                storyHtmlTextbox.Text = await File.ReadAllTextAsync(convertedPath);
            }
            mainContainer.SelectedIndex += 1;
        }

        private void schedulePostButton_Click(object sender, EventArgs e)
        {
            bool result = false;
            Chapter story = new Chapter();
            story.ChapterTitle = chapterTitleTextbox.Text;
            story.PublishingDate = publishingDatePicker.Value;
            story.ChapterSummary = chapterSummaryTextbox.Text;
            story.ChapterNotes = chapterNotesTextbox.Text;
            story.NotesAtStart = notesAtStartCheckbox.Checked;
            story.NotesAtEnd = notesAtEndCheckbox.Checked;
            story.ChapterTitle = worksComboBox.Text;
            story.Contents = storyHtmlTextbox.Text;

            if (_updatePost)
            {
                //story.Id = _preloadId.Value;
                //result = _storyController.UpdateStory(0, story);
            }
            else
            {
                /*story.AuthorId = _session.GetAuthor().Id;
                story.WebStoryId = _workIndexToIdVec[worksComboBox.SelectedIndex];
                result = _storyController.InsertStory(story);*/
            }

            if (!result)
            {
                MessageBox.Show(
                    "Failed to schedule story update. Check error log for more details.",
                    "Couldn't schedule post",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                //_logger.Error($"Failed to schedule story update, internal id={story.Id}, work id={story.WebStoryId}");
            }
            else
            {
                //_logger.Info($"Scheduled story update, internal id={story.Id}, work id={story.WebStoryId}");
            }

            Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(
                       "Are you sure you want to delete this story update? This action cannot be undone",
                       "Delete story",
                       MessageBoxButtons.YesNo,
                       MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                if (_storyController.DeleteStory(_preloadId.Value))
                {
                    _logger.Info($"Scheduled story deleted, internal id {_preloadId.Value}");
                }
                else
                {
                    _logger.Error($"Failed to delete scheduled story, internal id {_preloadId.Value}");
                }
            }



            Close();
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            var res = openFileDialog.ShowDialog();
            if (res == DialogResult.OK) filePathTextbox.Text = openFileDialog.FileName;
        }

        private void backFinalButton_Click(object sender, EventArgs e)
        {
            mainContainer.SelectedIndex--;
        }
    }
}
