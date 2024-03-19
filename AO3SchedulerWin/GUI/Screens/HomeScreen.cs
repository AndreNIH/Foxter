using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Controllers.AuthorControllers;
using AO3SchedulerWin.Controllers.ChapterControllers;
using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Publisher;
using AO3SchedulerWin.Publisher.Notifier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZetaIpc.Runtime.Server;

namespace AO3SchedulerWin.Forms
{
    public partial class HomeScreen : Form, IPublishEventListener
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public HomeScreen(IAuthorModel authorModel, IChapterModel chapterModel, Ao3Session session, PublishNotifier notifier)
        {
            InitializeComponent();
            _authorController = new DisplayAuthorController(authorModel, authorLabel);
            _chapterDisplayController = new ChapterStatusController(chapterModel, pendingUploadLabel, failedUploadLabel, session.Id);
            _notifier = notifier;
            _notifier.Subscribe(this);
        }


        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await _authorController.UpdateViews();
            await _chapterDisplayController.RefreshUI();
        }

        protected override void OnClosed(EventArgs e)
        {
            _notifier.Unsubscribe(this);
        }

        public async Task  OnPublish()
        {
            _logger.Info("publishing  triggered UI update");
            await _chapterDisplayController.RefreshUI();
        }

        private IAuthorController _authorController;
        private IChapterController _chapterDisplayController;
        private PublishNotifier _notifier;
    }
}
