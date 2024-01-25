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
using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Views.ChapterViews.TableView;
using AO3SchedulerWin.Models.Base;
using AO3SchedulerWin.Controllers.ChapterControllers;

namespace AO3SchedulerWin.Forms
{
    
    public partial class SchedulerScreen : Form
    {
        public SchedulerScreen(Ao3Session session, IChapterModel model)
        {
            InitializeComponent();
            _controller = new ChapterTableController(model, storyListContainer, mainContainer, session);
            _session = session;
            _model = model;
            
        }



        private async void schedulePostButton_Click(object sender, EventArgs e)
        {
            //var form = new ScheduleStoryForm(new ScheduleNewStoryBehavior(_session, _model));
            //form.ShowDialog();
            var form = new ScheduleStoryForm(_model, new Ao3Client(_session));
            form.ShowDialog();
            await _controller.RefreshUI();
        }

        protected override async void OnLoad(EventArgs e)
        {
            mainContainer.Appearance = TabAppearance.FlatButtons;
            mainContainer.ItemSize = new Size(0, 1);
            mainContainer.SizeMode = TabSizeMode.Fixed;
            await _controller.RefreshUI();
        }


        private IChapterModel _model;
        private ChapterTableController _controller;
        private Ao3Session _session;
    }

    

    
}
