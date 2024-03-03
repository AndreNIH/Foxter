using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.GUI.ChapterViews.TableView;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.GUI;
using AO3SchedulerWin.GUI.ChapterViews;
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
using static System.Net.Mime.MediaTypeNames;

namespace AO3SchedulerWin.Forms
{
    public partial class ChapterTableItem : UserControl
    {
        private ITableEventListener _updateListener; //Used to update view
        private IChapterModel _model;
        private Ao3Client _session; //Must be passed as a param because the object holds a state (Set on AppLoad or on account switch)
        private int _postId; //Corresponds to the internal id of the story in the database(not the Work ID on AO3)
        private static log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(ChapterTableItem));

        public ChapterTableItem(
            ITableEventListener listener,
            int id,
            string storyTitle,
            string chapterTitle,
            DateTime publishingDate
        )
        {
            InitializeComponent();
            _updateListener = listener;
            _postId = id;

            storyTitleLabelRHS.Text = storyTitle;
            chapterTitleLabelRHS.Text = chapterTitle;
            var longDate = publishingDate.ToLongDateString();
            var shortDate = publishingDate.ToShortDateString();
            if (publishingDate < DateTime.Now)
            {
                publishingDateLabelRHS.Text = $"Failed to upload on {longDate}, {shortDate}";
                publishingDateLabelRHS.ForeColor = Color.Red;
            }
            else
            {
                publishingDateLabelRHS.Text = $"{longDate}, {shortDate}";
            }



        }

        public int GetId()
        {
            return _postId;
        }

        private async void editButton_Click(object sender, EventArgs e)
        {
            await _updateListener.OnEditChapter(this);
        }


    }
}
