using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Controllers.AuthorControllers;
using AO3SchedulerWin.Controllers.ChapterControllers;
using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZetaIpc.Runtime.Server;

namespace AO3SchedulerWin.Forms
{
    public partial class HomeScreen : Form
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public HomeScreen(IAuthorModel authorModel, IChapterModel chapterModel, Ao3Session session)
        {
            InitializeComponent();
            _authorController = new DisplayAuthorController(authorModel, authorLabel);
            _chapterDisplayController = new ChapterStatusController(chapterModel, pendingUploadLabel, failedUploadLabel, session.Id);
            _ipcServer = new IpcServer();
            SetupIPC();
          
        }

        private void SetupIPC() {
            try
            {
                int port = 55551;
                _ipcServer.Start(port);
                _ipcServer.ReceivedRequest += async (sender, args) =>
                {
                    args.Handled = true;
                    this.Invoke((MethodInvoker)async delegate
                    {
                        _logger.Info("IPC update request received");
                        await _chapterDisplayController.RefreshUI();
                    });
                };
                _ipcServerStarted = true;
                _logger.Info("IPC server started on port " + port);
            }
            catch
            {
                _logger.Warn("IPC initialization error");
            }
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            await _authorController.UpdateViews();
            await _chapterDisplayController.RefreshUI();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (_ipcServerStarted)
            {
                _ipcServer.Stop();
                _logger.Info("Stopped IPC server");
            }
        }


        private IAuthorController _authorController;
        private IChapterController _chapterDisplayController;
        private IpcServer _ipcServer;
        private bool _ipcServerStarted;
    }
}
