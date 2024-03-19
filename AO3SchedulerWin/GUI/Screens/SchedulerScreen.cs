using AO3SchedulerWin.Controllers;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.GUI;
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
using AO3SchedulerWin.GUI.ChapterViews.TableView;
using AO3SchedulerWin.Models.Base;
using AO3SchedulerWin.Controllers.ChapterControllers;
using ZetaIpc.Runtime.Server;
using AO3SchedulerWin.Publisher.Notifier;

namespace AO3SchedulerWin.Forms
{

    public partial class SchedulerScreen : Form, IPublishEventListener
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public SchedulerScreen(Ao3Session session, IChapterModel model, PublishNotifier notifier)
        {
            InitializeComponent();
            _controller = new ChapterTableController(model, storyListContainer, mainContainer, session);
            _session = session;
            _model = model;
            _notifier = notifier;
            _notifier.Subscribe(this);
        }


        protected override void OnClosed(EventArgs e)
        {
            _notifier.Unsubscribe(this);
        }

        private void schedulePostButton_Click(object sender, EventArgs e)
        {
            var formController = new NewChapterController(_model, _session);
            formController.ShowForm();
        }

        protected override async void OnLoad(EventArgs e)
        {
            mainContainer.Appearance = TabAppearance.FlatButtons;
            mainContainer.ItemSize = new Size(0, 1);
            mainContainer.SizeMode = TabSizeMode.Fixed;
            await _controller.RefreshUI();
        }

        public async Task OnPublish()
        {
            _logger.Info("publishing  triggered UI update");
            await _controller.RefreshUI();
        }

        private IChapterModel _model;
        private ChapterTableController _controller;
        private Ao3Session _session;
        private PublishNotifier _notifier;
    }




}
