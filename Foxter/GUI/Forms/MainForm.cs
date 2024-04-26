using Foxter.AO3;
using Foxter.Factories;
using Foxter.Forms;
using Foxter.GUI.Forms;
using Foxter.GUI.Screens;
using Foxter.Models;
using Foxter.Publisher;
using Foxter.Publisher.Notifier;
using Foxter.Settings;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Foxter
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
        private SessionManager _sessionMgr;
        private Form _activeForm;
        private PublishNotifier _publishNotifier;
        private System.Timers.Timer _publishTimer;
        private bool _supressFormClosing;

        public MainForm(IAppServiceFactory serviceFactory, SessionManager sessionMgr)
        {
            InitializeComponent();
            _authorModel = serviceFactory.CreateAuthorModel();
            _chapterModel = serviceFactory.CreateChapterModel();
            _sessionMgr = sessionMgr;

            //Publishing
            _publishNotifier = new PublishNotifier();

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

            //Supress closing
            _supressFormClosing = true;


        }

        private void CloseTrayBtn_Click(object? sender, EventArgs e)
        {
            _supressFormClosing = false;
            Close();
        }

        private async void publishTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            //Stop the timer loop if the window handle is no longer valid
            //if (!IsHandleCreated || InvokeRequired) return;

            //If the user isn't logged just skip
            if (_sessionMgr.HasActiveSession() == false) return;
            Invoke((MethodInvoker)async delegate
        {
            try
            {
                //This approach is not flexible, move publishing strategy
                //into the service factory.
                //Also this is not very performnt, because of the multip
                var publishingStrategy = new LocalPublishingStrategy(_authorModel, _chapterModel, _sessionMgr.GetExistingSession());
                var publisher = new PublisherClient(publishingStrategy, _publishNotifier);
                await publisher.PublishChapters();
            }
            catch (Ao3GenericException ex)
            {
                _logger.Error("an AO3 exception was thrown trying to publish a chapter: " + ex.Message);
            }

            _publishTimer.Start(); //keep the clock running
        });
        }

        //Form Overrides
        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
            versionLabel.Text = "Version: " + (assemblyName != null ? assemblyName.Version : "N/A");
            bool logged = (await _authorModel.Get()) != null;
            if (logged) ChangeScreen(ScreenId.MAIN);
            else ChangeScreen(ScreenId.LOGIN);

        }


        private void SendToTray()
        {
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(500);
            Hide();
        }

        //Override default close behavior
        //to minimize the app(instead of closing).
        //Othwerwise, call Application.Exit() to get rid of AppLoaderForm
        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool logged = (await _authorModel.Get()) != null;
            if (_supressFormClosing && logged && SettingsManager.Get.Configuration.sendToTray)
            {
                e.Cancel = true;
                SendToTray();
            }
            else
            {
                Application.Exit();
            }
        }

        //Ensure the application actually closes
        //instead of hanging on the hidden ApplicationLoader form
        protected override void OnClosed(EventArgs e)
        {
            Application.Exit();
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
            Close();
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
                const int WS_MINIMIZEBOX = 0x20000;
                const int CS_DBLCLKS = 0x8;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW | CS_DBLCLKS;
                cp.Style |= WS_MINIMIZEBOX;
                return cp;
            }
        }

        //Reset Sidebar Button Colors
        private void ClearSidebarStyle()
        {
            var color = Color.FromArgb(60, 60, 60);
            homeButton.BackColor = color;
            scheduleButton.BackColor = color;
            accountsButton.BackColor = color;
            settingsButton.BackColor = color;
        }

        //Screen-id to scene mapping
        public void ChangeScreen(ScreenId screenId)
        {
            _logger.Info($"Transitioning to scene id:{screenId}");
            ClearSidebarStyle();
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            var activeColor = Color.FromArgb(72, 72, 72);
            switch (screenId)
            {
                case ScreenId.MAIN:
                    {
                        var screen = new HomeScreen(_authorModel, _chapterModel, _sessionMgr.GetExistingSession(), _publishNotifier);
                        SetMainContent(screen);
                        homeButton.BackColor = activeColor;
                        break;
                    }

                case ScreenId.SCHEDULE:
                    {

                        var screen = new SchedulerScreen(_session, _chapterModel, _publishNotifier);
                        SetMainContent(screen);
                        scheduleButton.BackColor = activeColor;
                        break;
                    }
                case ScreenId.LOGIN:
                    {
                        var screen = new LoginScreen(ref _session, _authorModel, this);
                        SetMainContent(screen);
                        accountsButton.BackColor = activeColor;
                        break;
                    }
                case ScreenId.LOGGED_IN:
                    {
                        var screen = new LoggedUserScreen(ref _session, _authorModel, this);
                        SetMainContent(screen);
                        accountsButton.BackColor = activeColor;
                        break;
                    }
                case ScreenId.NO_USER:
                    {
                        var screen = new NoActiveUserScreen();
                        SetMainContent(screen);
                        accountsButton.BackColor = activeColor;
                        break;
                    }
                case ScreenId.SETTINGS:
                    {
                        var screen = new SettingsScreen();
                        SetMainContent(screen);
                        settingsButton.BackColor = activeColor;
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
            if (logged) ChangeScreen(ScreenId.MAIN);
            else ChangeScreen(ScreenId.NO_USER);
        }


        private async void scheduleButton_Click(object sender, EventArgs e)
        {
            bool logged = (await _authorModel.Get()) != null;
            if (logged) ChangeScreen(ScreenId.SCHEDULE);
            else ChangeScreen(ScreenId.NO_USER);
        }

        private async void accountsButton_Click(object sender, EventArgs e)
        {
            bool logged = (await _authorModel.Get()) != null;
            if (logged) ChangeScreen(ScreenId.LOGGED_IN);
            else ChangeScreen(ScreenId.LOGIN);

        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            ChangeScreen(ScreenId.SETTINGS);
        }


        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            notifyIcon.Visible = false;
        }

       
    }
}