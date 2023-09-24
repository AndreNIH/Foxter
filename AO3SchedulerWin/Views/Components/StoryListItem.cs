using AO3SchedulerWin.Models.StoryModels;
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
        private int _storyId;
        public StoryListItem(Ao3Session session, IStoryModel model, int storyId)
        {
            InitializeComponent();
            _model = model;
            _storyId = storyId;
            _session = session;

            var story = _model.GetStory(_storyId);
            storyTitleLabelRHS.Text = story.Title;
            chapterTitleLabelRHS.Text = story.ChapterTitle;
            publishingDateLabelRHS.Text = story.PublishingDate.ToLongDateString();

        }


        private void editButton_Click(object sender, EventArgs e)
        {
            var form = new ScheduleStoryForm(_session, _model, _storyId);
        }


    }
}
