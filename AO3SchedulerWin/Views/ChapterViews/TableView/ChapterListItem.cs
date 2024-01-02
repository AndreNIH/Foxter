using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Views;
using AO3SchedulerWin.Views.ChapterViews;
using AO3SchedulerWin.Views.ChapterViews.TableView;
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
        private  ITableUpdateListener _updateListener; //Used to update view
        private IChapterModel _model;
        private Ao3Client _session; //Must be passed as a param because the object holds a state (Set on AppLoad or on account switch)
        private int _postId; //Corresponds to the internal id of the story in the database(not the Work ID on AO3)
        private static log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(ChapterTableItem));
        
        public ChapterTableItem(
            ITableUpdateListener listener, 
            IChapterModel model, 
            Ao3Client session, 
            int id,
            string storyTitle,
            string chapterTitle,
            DateTime publishingDate
        )
        {
            InitializeComponent();
            _updateListener = listener;
            _postId = id;
            _session = session;
            _model = model;
            
            storyTitleLabelRHS.Text = storyTitle;
            chapterTitleLabelRHS.Text = chapterTitle;
            var longDate  = publishingDate.ToLongDateString();
            var shortDate = publishingDate.ToShortDateString();
            if(publishingDate < DateTime.Now)
            {
                publishingDateLabelRHS.Text = $"Failed to upload on {longDate}, {shortDate}";
                publishingDateLabelRHS.ForeColor = Color.Red;
            }
            else
            {
                publishingDateLabelRHS.Text = $"{longDate}, {shortDate}";
            }

            
            
        }


        private void editButton_Click(object sender, EventArgs e)
        {
            //var form = new ScheduleStoryForm(_session, _model, _storyPostId);
            //form.ShowDialog();
            _updateListener.NotifyUpdate();
        }


    }
}
