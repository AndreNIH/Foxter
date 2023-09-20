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
using AO3SchedulerWin.Models.AuthorModels;

namespace AO3SchedulerWin.Forms
{
    public partial class SchedulerScreen : Form
    {
        public SchedulerScreen(Ao3Session session)
        {
            InitializeComponent();
            _model = new LocalStoryModel();
            _tableView = new StoryListViewAdapter(storyListContainer);
            _storyController = new StoryTableController(_tableView, _model);
            _authorModel = new AuthorLocalModel();
            _session = session;


        }

        private void reloadScreen()
        {
            mainContainer.SelectedIndex = 1; //storyListContainer.Controls.Count > 0 ? 1 : 0;
            _storyController.UpdateViews();
        }

        private void schedulePostButton_Click(object sender, EventArgs e)
        {
            var form = new ScheduleStoryForm(_session, _storyController);
            form.ShowDialog();
            reloadScreen();
        }

        protected override void OnLoad(EventArgs e)
        {
            mainContainer.Appearance = TabAppearance.FlatButtons;
            mainContainer.ItemSize = new Size(0, 1);
            mainContainer.SizeMode = TabSizeMode.Fixed;

            reloadScreen();
        }

        private IStoryController _storyController;
        private IStoryModel _model;
        private IAuthorModel _authorModel;
        private IStoryView _tableView;
        private Ao3Session _session;



    }
}
