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
        public StoryListItem()
        {
            InitializeComponent();
        }

        private void FicListItem_Load(object sender, EventArgs e)
        {

        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                storyTitleLabelRHS.Text = value;
            }
        }

        public string ChapterTitle
        {
            get { return _chapterTitle; }
            set
            {
                _chapterTitle = value;
                chapterTitleLabelRHS.Text = value;
            }
        }

        public DateTime PublishingDate
        {
            get { return _publishingDate; }
            set
            {
                _publishingDate = value;
                //TODO: Map to an actual label
                publishingDateLabelRHS.Text = _publishingDate.ToLongDateString();
            }
        }


        private string _title;
        private string _chapterTitle;
        private DateTime _publishingDate;

    }
}
