using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AO3SchedulerWin.Forms.BaseSchedulerBehavior;

namespace AO3SchedulerWin.Views.ChapterViews
{
    public abstract class BaseChapterFormView
    {

        public class BoxItem
        {
            public string DisplayField { get; set; }
            public int Id { get; set; }
            public BoxItem(string displayName, int id)
            {
                DisplayField = displayName;
                Id = id;
            }
        }

        //Data sources
        private List<BoxItem> _storyDS = new List<BoxItem>();
        private List<BoxItem> _chapterDS = new List<BoxItem>();

        //Views
        public ComboBox storyBoxWidget { protected get; set; }
        public ComboBox chapterBoxWidget { protected get; set; }

        
        protected void RefreshDataSources()
        {

        }
        
        public void PopulateStoriesBox(List<BoxItem> items)
        {
            _storyDS.Clear();
            _storyDS.AddRange(items);
            storyBoxWidget.DataSource = null;
            storyBoxWidget.DataSource = _storyDS;
            storyBoxWidget.DisplayMember = "DisplayField";
            storyBoxWidget.ValueMember = "Id";
        }

        public void PopulateChaptersBox(List<BoxItem> items)
        {
            _chapterDS.Clear();
            _chapterDS.AddRange(items);
            chapterBoxWidget.DataSource = null;
            chapterBoxWidget.DataSource = _chapterDS;
            chapterBoxWidget.DisplayMember = "DisplayField";
            chapterBoxWidget.ValueMember = "Id";
        }




        public BaseChapterFormView(ComboBox storyBox, ComboBox chapterBox, Button openInAo3Button)
        {
            storyBoxWidget = storyBox;
            chapterBoxWidget = chapterBox;
            storyBoxWidget.ValueMember = "Id";
            chapterBoxWidget.ValueMember = "Id";
            storyBoxWidget.DisplayMember = "Display";
            chapterBoxWidget.DisplayMember = "Display";
            openInAo3Button.Click += OpenInAo3Button_Click;

        }

        private void OpenInAo3Button_Click(object? sender, EventArgs e)
        {
            var selectedWorkId = storyBoxWidget.SelectedValue;
            var selectedChapterId = chapterBoxWidget.SelectedValue;
            if (selectedWorkId != null && selectedChapterId != null)
            {
                var workId = (int)selectedWorkId;
                var chapterId = (int)selectedChapterId;
                Process.Start("explorer", $"https://archiveofourown.org/works/{workId}/chapters/{chapterId}/edit");
            }

        }
    }
}
