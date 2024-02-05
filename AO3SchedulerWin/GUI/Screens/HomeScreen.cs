using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Controllers.AuthorControllers;
using AO3SchedulerWin.Controllers.ChapterControllers;
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
        public HomeScreen(IAuthorModel authorModel, IChapterModel chapterModel, Ao3Session session)
        {
            InitializeComponent();
            _authorController = new DisplayAuthorController(authorModel, new AuthorLabelViewAdapter(authorLabel));
            _chapterDisplayController = new ChapterStatusController(chapterModel, pendingUploadLabel, failedUploadLabel, session.Id);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _authorController.UpdateViews();
            _chapterDisplayController.RefreshUI();
        }

        private IAuthorController _authorController;
        private IChapterController _chapterDisplayController;
    }
}
