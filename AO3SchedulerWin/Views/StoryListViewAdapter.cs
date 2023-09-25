using AO3SchedulerWin.Forms;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Models.StoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Views
{
    internal class StoryListViewAdapter : IStoryView
    {
        
        public StoryListViewAdapter(TableLayoutPanel layoutPanel, Ao3Session ao3Session, IStoryModel storyModel)
        {
            _layoutPanel = layoutPanel;
            _ao3Session = ao3Session;
            _storyModel = storyModel;
        }

        public void UpdateView(List<Story> stories)
        {
            _layoutPanel.SuspendLayout();
            _layoutPanel.Controls.Clear();
            foreach (var story in stories)
            {
                StoryListItem item = new StoryListItem(_ao3Session,_storyModel, story.Id);
                item.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                _layoutPanel.Controls.Add(item);
            }
            _layoutPanel.ResumeLayout();
        }

        private TableLayoutPanel _layoutPanel;
        private Ao3Session _ao3Session;
        private IStoryModel _storyModel;


    }
}
