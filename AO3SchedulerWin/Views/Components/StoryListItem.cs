using AO3SchedulerWin.Models.StoryModels;
using AO3SchedulerWin.Views;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AO3SchedulerWin.Forms
{
    public partial class StoryListItem : UserControl
    {
        private IStoryModel _model;
        private Ao3Session _session;
        private int _storyPostId; //Corresponds to the internal id of the story in the database(not the Work ID on AO3)
        StoryListViewAdapter _layout;
        private static log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(StoryListItem));
        public StoryListItem(StoryListViewAdapter layout, Ao3Session session, IStoryModel model, int id)
        {
            InitializeComponent();
            _layout = layout;
            _model = model;
            _storyPostId = id;
            _session = session;
            var story = _model.GetStory(_storyPostId);
            storyTitleLabelRHS.Text = story.Title;
            chapterTitleLabelRHS.Text = story.ChapterTitle;
            publishingDateLabelRHS.Text = story.PublishingDate.ToLongDateString();
            _logger.Info($"Created StoryListItem for story '{story.StoryId}'. Internal Id: {id}");
        }


        private void editButton_Click(object sender, EventArgs e)
        {
            var form = new ScheduleStoryForm(_session, _model, _storyPostId);
            form.ShowDialog();
            //aaaaaaah this is so bad
            _layout.UpdateView(_model.GetStories()); 
        }


    }
}
