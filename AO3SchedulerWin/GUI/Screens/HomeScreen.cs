using AO3SchedulerWin.Controllers.AuthorControllers;
using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Views.AuthorViews;
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
    public partial class HomeScreen : Form
    {
        public HomeScreen(IAuthorModel model)
        {
            InitializeComponent();
            _authorController = new DisplayAuthorController(model ,new AuthorLabelViewAdapter(authorLabel));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _authorController.UpdateViews();
        }

        private IAuthorController _authorController;
        private IChapterController _queuedStoriesController;
    }
}
