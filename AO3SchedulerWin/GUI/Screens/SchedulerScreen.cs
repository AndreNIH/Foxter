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

namespace AO3SchedulerWin.Forms
{
    public partial class SchedulerScreen : Form
    {
        public SchedulerScreen()
        {
            InitializeComponent();
            _model = new LocalStoryModel();
            _tableView = new StoryListViewAdapter(storyListContainer);
            _controller = new StoryController(_tableView, _model);
            _controller.UpdateViews();


        }

        private void schedulePostButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                var story = new Story();
                
                story.AuthorId = 0;
                story.StoryId = 1;
                story.Title = "Great Story";
                story.ChapterTitle = "A new Chapter(On digital marketing)";
                story.PublishingDate = DateTime.Now;
                story.ChapterSummary = "Summary";
                story.ChapterNotes = "Notes";
                story.NotesAtStart = false; story.NotesAtEnd = false;
                story.Contents = "This is the content of the story";
                _controller.InsertStory(story);
            }
            _controller.UpdateViews();
        }

        IStoryController _controller;
        IStoryModel _model;
        IStoryView _tableView;
    }
}
