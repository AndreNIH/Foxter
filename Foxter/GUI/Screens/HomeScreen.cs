﻿using Foxter.AO3;
using Foxter.Controllers.AuthorControllers;
using Foxter.Controllers.ChapterControllers;
using Foxter.Controllers.StoryControllers;
using Foxter.Models;
using Foxter.Publisher;
using Foxter.Publisher.Notifier;
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

namespace Foxter.Forms
{
    public partial class HomeScreen : Form, IPublishEventListener
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()!.DeclaringType);
        private ISession _session;
        private IChapterController _chapterDisplayController;
        private PublishNotifier _notifier;

        public HomeScreen(IAuthorModel authorModel, IChapterModel chapterModel, ISession session, PublishNotifier notifier)
        {
            InitializeComponent();
            _session = session;
            _chapterDisplayController = new ChapterStatusController(chapterModel, pendingUploadLabel, failedUploadLabel, session.GetId());
            _notifier = notifier;
            _notifier.Subscribe(this);
        }


        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            authorLabel.Text = _session.GetUser();
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

        
    }
}
