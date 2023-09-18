using AO3SchedulerWin.Controllers;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AO3SchedulerWin.Models.StoryModels;
using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.Models.AuthorModels;

namespace AO3SchedulerWin.Forms
{
    public partial class SchedulerScreen : Form
    {
        public SchedulerScreen(Ao3Session session)
        {
            InitializeComponent();
            _model = new LocalStoryModel();
            _tableView = new StoryListViewAdapter(storyListContainer);
            _storyController = new StoryTableController(_tableView, _model);
            _authorModel = new AuthorLocalModel();
            _session = session;
            _storyController.UpdateViews();
            

        }

        private void reloadScreen()
        {
            mainContainer.SelectedIndex = storyListContainer.Controls.Count > 0 ? 1 : 0;
            _storyController.UpdateViews();
        }

        private void schedulePostButton_Click(object sender, EventArgs e)
        {
            /*for (int i = 0; i < 1; i++)
            {
                var story = new Story();

                story.AuthorId = _authorModel.GetActiveAuthor().Id;
                story.StoryId = 1;
                story.Title = "Great Story";
                story.ChapterTitle = "A new Chapter(On digital marketing)";
                story.PublishingDate = DateTime.Now;
                story.ChapterSummary = "Summary";
                story.ChapterNotes = "Notes";
                story.NotesAtStart = false; story.NotesAtEnd = false;
                story.Contents = "This is the content of the story";
                _controller.InsertStory(story);
            }*/
            var form = new ScheduleStoryForm(_session, _storyController);
            form.ShowDialog();
            _storyController.UpdateViews();
            reloadScreen();
        }

        private void SchedulerScreen_Load(object sender, EventArgs e)
        {
            mainContainer.Appearance = TabAppearance.FlatButtons;
            mainContainer.ItemSize = new Size(0, 1);
            mainContainer.SizeMode = TabSizeMode.Fixed;

            reloadScreen();
        }

        private IStoryController _storyController;
        private IStoryModel _model;
        private IAuthorModel _authorModel;
        private IStoryView _tableView;
        private Ao3Session _session;
        


    }
}
