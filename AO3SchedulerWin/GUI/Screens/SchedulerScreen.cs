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

namespace AO3SchedulerWin.Forms
{

    public partial class SchedulerScreen : Form
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public SchedulerScreen(Ao3Session session, IChapterModel model)
        {
            InitializeComponent();
            _controller = new ChapterTableController(model, storyListContainer, mainContainer, session);
            _session = session;
            _model = model;
            _ipcServerStarted = false;
            _ipcServer = new IpcServer();
            SetupIPC();
        }

        private void SetupIPC()
        {
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
                        await _controller.RefreshUI();
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

        protected override void OnClosed(EventArgs e)
        {
            if (_ipcServerStarted)
            {
                _ipcServer.Stop();
                _logger.Info("Stopped IPC server");
            }
        }

        private void schedulePostButton_Click(object sender, EventArgs e)
        {
            //var form = new ScheduleStoryForm(new ScheduleNewStoryBehavior(_session, _model));
            //form.ShowDialog();
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


        private IChapterModel _model;
        private ChapterTableController _controller;
        private Ao3Session _session;
        private IpcServer _ipcServer;
        private bool _ipcServerStarted;
    }




}
