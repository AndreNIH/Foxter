using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Factories;
using AO3SchedulerWin.Forms;
using AO3SchedulerWin.GUI.Forms;
using AO3SchedulerWin.GUI.Screens;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Publisher;
using AO3SchedulerWin.Publisher.Notifier;
using System.Runtime.InteropServices;

namespace AO3SchedulerWin
{
    public partial class MainForm : Form, IScreenUpdater
    {

        //WinAPI DLL Imports
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwndm, int msg, int wParam, int lParam);
        //End of external DLL imports

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IAuthorModel _authorModel;
        private IChapterModel _chapterModel;
        private Ao3Session _session;
        private Form _activeForm;
        private PublisherClient _publisher;
        private PublishNotifier _publishNotifier;
        private System.Timers.Timer _publishTimer;

        public MainForm(IAppServiceFactory serviceFactory, Ao3Session session)
        {
            InitializeComponent();
            _authorModel = serviceFactory.CreateAuthorModel();
            _chapterModel = serviceFactory.CreateChapterModel();
            _session = session;
            
            //Publishing
            var publishingStrategy = new LocalPublishingStrategy(_authorModel, _chapterModel, session);
            _publishNotifier = new PublishNotifier();
            _publisher = new PublisherClient(publishingStrategy, _publishNotifier);
            _publishTimer = new(3000);
            _publishTimer.Elapsed += publishTimer_Elapsed;
            _publishTimer.AutoReset = false;
            _publishTimer.Start();

            //Tray icon
            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            var closeTrayBtn = notifyIcon.ContextMenuStrip.Items.Add("Close application");
            closeTrayBtn.Click += CloseTrayBtn_Click;

            //Resizing
            MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;



        }

        private void CloseTrayBtn_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void publishTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke((MethodInvoker)async delegate
            {
                await _publisher.PublishChapters();
                _publishTimer.Start(); //keep the clock running
            });
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            bool logged = (await _authorModel.Get()) != null;
            if (logged) await ChangeScreen("SC_MAIN");
            else await ChangeScreen("SC_LOGIN");

        }
        //Child Form Loading
        private void SetMainContent(Form childForm)
        {
            if (_activeForm != null) _activeForm.Close();
            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.Padding = new Padding(10);
            mainContentPanel.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.AutoScroll = true;
            childForm.Show();

        }


        //Top Panel Dragging
        private void topBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void formTitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //Form Size Controls
        private void closeButton_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(500);
            Hide();
        }

        private void maximizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = WindowState == FormWindowState.Normal
                ? FormWindowState.Maximized
                : FormWindowState.Normal;
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        //Form Drop Shadow
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }



        //Screen-id to scene mapping
        public async Task ChangeScreen(string screenId)
        {
            _logger.Info($"Transitioning to screen with id {screenId}");
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            switch (screenId)
            {
                case "SC_MAIN":
                    {
                        var screen = new HomeScreen(_authorModel, _chapterModel, _session, _publishNotifier);
                        SetMainContent(screen);
                        break;
                    }

                case "SC_SCHEDULE":
                    {

                        var screen = new SchedulerScreen(_session, _chapterModel, _publishNotifier);
                        SetMainContent(screen);
                        break;
                    }
                case "SC_LOGIN":
                    {
                        var screen = new LoginScreen(ref _session, _authorModel, this);
                        SetMainContent(screen);
                        break;
                    }
                case "SC_LOGGED":
                    {
                        var screen = new LoggedUserScreen(ref _session, _authorModel, this);
                        SetMainContent(screen);
                        break;
                    }
                case "SC_LOGREQUIRED":
                    {
                        var screen = new NoActiveUserScreen();
                        SetMainContent(screen);
                        break;
                    }
                case "SC_SETTINGS":
                    {
                        var screen = new SettingsScreen();
                        SetMainContent(screen);
                        break;
                    }
                default:
                    {
                        _logger.Warn($"screen-id {screenId} doesn't exist");
                        break;
                    }
            }
        }



        //Sidebar Buttons
        private async void homeButton_Click(object sender, EventArgs e)
        {
            bool logged = (await _authorModel.Get()) != null;
            if (logged) await ChangeScreen("SC_MAIN");
            else await ChangeScreen("SC_LOGREQUIRED");
        }


        private async void scheduleButton_Click(object sender, EventArgs e)
        {
            bool logged = (await _authorModel.Get()) != null;
            if (logged) await ChangeScreen("SC_SCHEDULE");
            else await ChangeScreen("SC_LOGREQUIRED");
        }

        private async void accountsButton_Click(object sender, EventArgs e)
        {
            bool logged = (await _authorModel.Get()) != null;
            if (logged) await ChangeScreen("SC_LOGGED");
            else await ChangeScreen("SC_LOGIN");

        }

        private async void settingsButton_Click(object sender, EventArgs e)
        {
            await ChangeScreen("SC_SETTINGS");
        }


        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }
    }
}