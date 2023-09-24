using AO3SchedulerWin.Forms;
using AO3SchedulerWin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Views
{
    internal class StoryListViewAdapter : IStoryView
    {
        public StoryListViewAdapter(TableLayoutPanel layoutPanel)
        {
            _layoutPanel = layoutPanel;
        }

        public void UpdateView(List<Story> stories)
        {
            _layoutPanel.SuspendLayout();
            _layoutPanel.Controls.Clear();
            foreach (var story in stories)
            {
                //#TODO: Find a way to pass around model/session data to this
                StoryListItem item = new StoryListItem();
                item.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                _layoutPanel.Controls.Add(item);
            }
            _layoutPanel.ResumeLayout();
        }

        TableLayoutPanel _layoutPanel;

        
    }
}
