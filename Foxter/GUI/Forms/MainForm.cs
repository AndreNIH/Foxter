using Accessibility;
using Foxter.AO3.Exceptions;
using Foxter.Forms;
using Foxter.GUI.Forms;
using Foxter.GUI.Screens;
using Foxter.Models;
using Foxter.Providers;
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

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()!.DeclaringType);
        private IAuthorModel _authorModel;
        private IChapterModel _chapterModel;
        private SessionManager _sessionMgr;
        private Form _activeForm;
        private PublishNotifier _publishNotifier;
        private System.Timers.Timer _publishTimer;
        private System.Timers.Timer _networkMonitorTimer;
        private bool _supressFormClosing;
        private bool _hidden;
        private bool _networkErrorState;
        private PublisherClient _publisher;
        static HttpClient _networkProbeClient = new HttpClient();


        public MainForm(IDatabaseProvider dbProvider, SessionManager sessionMgr, bool hidden=false, bool offline=false)
        {
            InitializeComponent();
            //Models/Services
            _authorModel = dbProvider.GetAuthorModel();
            _chapterModel = dbProvider.GetChapterModel();
            _sessionMgr = sessionMgr;

            //Plain Old Data/Misc
            _networkErrorState = false;



            //Publishing
            _publishNotifier = new PublishNotifier();
            _publisher = new PublisherClient(_publishNotifier);

            _publishTimer = new(3000);
            _publishTimer.Elapsed += publishTimer_Elapsed;
            _publishTimer.AutoReset = false;
            _publishTimer.Start();
            _logger.Info("publish timer started ticking");

            _networkMonitorTimer = new(5000);
            _networkMonitorTimer.Elapsed += networkMonitorTimer_Elapsed;
            _networkMonitorTimer.Start();
            _logger.Info("network timer started ticking");

            //Tray icon
            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            var closeTrayBtn = notifyIcon.ContextMenuStrip.Items.Add("Close application");
            closeTrayBtn.Click += CloseTrayBtn_Click;

            //Resizing
            MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            //Supress closing
            _supressFormClosing = true;

            //Startup hidden form
            bool sessDataExists = Task.Run(() => _sessionMgr.SessionDataExists()).Result;
            if(sessDataExists && _sessionMgr.HasActiveSession() == false && hidden)
            {
                _logger.Info("hidden launch override: session is in exceptional state");
                hidden = false;
            }
            
            _hidden = hidden;
            if (_hidden)
            {
                _logger.Info("application started up in hidden mode, sending to tray...");
                SendToTray();
            }

        }

        void ToggleNetworkErrorMode(bool enabled)
        {
            _logger.Info($"network error mode set to {enabled}");
            _networkErrorState = enabled;
            if (networkErrorPanel.InvokeRequired)
            {
                networkErrorPanel.Invoke(delegate { ToggleNetworkErrorMode(enabled); });
            }
            else
            {
                networkErrorPanel.Visible = enabled; 
            }
        }


        private async void networkMonitorTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            bool networkError = true;
            try
            {
                var response = await _networkProbeClient.GetStringAsync("http://www.msftncsi.com/ncsi.txt");
                if (response == "Microsoft NCSI")
                {
                    networkError = false;
                }
            }
            catch (HttpRequestException) { }
            catch (TimeoutException) {}
            
            //Prevent unecessary UI updates and logs from
            //being generated. Only update the state if
            //it actually changed
            if (_networkErrorState != networkError)
            {
                ToggleNetworkErrorMode(networkError);
            }
        }

        private void CloseTrayBtn_Click(object? sender, EventArgs e)
        {
            _logger.Info("CloseTrayBtn clicked");
            _supressFormClosing = false;
            Close();
        }

        private async void publishTimer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {

            //If the user isn't logged just skip
            if (_sessionMgr.HasActiveSession())
            {
                Invoke((MethodInvoker)async delegate
                {
                    try
                    {
                        //TODO: Refactor this
                        //This approach is not flexible, move publishing strategy
                        //The publishing strategy is hardcoded and we are creating instances
                        //on every upload attempt.
                        _publisher.SetPublishStrategy(new LocalPublishingStrategy(_chapterModel, _sessionMgr.GetExistingSession()));
                        await _publisher.PublishChapters();
                    }
                    catch (Ao3GenericException ex)
                    {
                        _logger.Error("an AO3 exception was thrown trying to publish a chapter: " + ex.Message);
                    }

                    _publishTimer.Start(); //keep the clock running
                });
            }
        }

        //Form Overrides
        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName();
            versionLabel.Text = "Version: " + (assemblyName != null ? assemblyName.Version : "N/A");
            

            if(await _sessionMgr.SessionDataExists() && _sessionMgr.HasActiveSession() == false)
            {
                ChangeScreen(ScreenId.BACKUP_LOGIN);
            }
            else
            {
                bool logged = _sessionMgr.HasActiveSession();
                if (logged) ChangeScreen(ScreenId.MAIN);
                else ChangeScreen(ScreenId.LOGIN);
            }
            
        }

        private void SendToTray()
        {
            _logger.Info("application sent to tray");
            notifyIcon.Visible = true;
            if(!_hidden) notifyIcon.ShowBalloonTip(500);
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
                _logger.Info("exiting application");
                Application.Exit();
            }
        }

        //Ensure the application actually closes
        //instead of hanging on the hidden ApplicationLoader form
        protected override void OnClosed(EventArgs e)
        {
            _publishTimer.Stop();
            _networkMonitorTimer.Stop();
            Application.Exit();
        }

        //Hide form on form Show
        protected override void SetVisibleCore(bool value)
        {
            //base.SetVisibleCore(value);
            base.SetVisibleCore(_hidden ? false : value);
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
            _logger.Info($"current active screen: {_activeForm}");


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
            _logger.Info($"screen change requested, moving to scene id:{screenId}");
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

                        var screen = new SchedulerScreen(_sessionMgr.GetExistingSession(), _chapterModel, _publishNotifier);
                        SetMainContent(screen);
                        scheduleButton.BackColor = activeColor;
                        break;
                    }
                case ScreenId.LOGIN:
                    {
                        var screen = new LoginScreen(_sessionMgr, _authorModel, this);
                        SetMainContent(screen);
                        accountsButton.BackColor = activeColor;
                        break;
                    }
                case ScreenId.LOGGED_IN:
                    {
                        var screen = new LoggedUserScreen(_sessionMgr, this);
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
                case ScreenId.BACKUP_LOGIN:
                    {
                        var screen = new BackupLoginScreen(_sessionMgr, this);
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
            _logger.Info("homeButton clicked");
            bool logged = _sessionMgr.HasActiveSession();
            if (logged) ChangeScreen(ScreenId.MAIN);
            else if (await _sessionMgr.SessionDataExists() && !logged) ChangeScreen(ScreenId.BACKUP_LOGIN);
            else ChangeScreen(ScreenId.LOGIN);
        }


        private async void scheduleButton_Click(object sender, EventArgs e)
        {
            _logger.Info("scheduleButton clicked");
            bool logged = _sessionMgr.HasActiveSession();
            if (logged) ChangeScreen(ScreenId.SCHEDULE);
            else if (await _sessionMgr.SessionDataExists() && !logged) ChangeScreen(ScreenId.BACKUP_LOGIN);
            else ChangeScreen(ScreenId.LOGIN);
        }

        private async void accountsButton_Click(object sender, EventArgs e)
        {
            _logger.Info("accountsButton clicked");
            bool logged = _sessionMgr.HasActiveSession();
            if (logged) ChangeScreen(ScreenId.LOGGED_IN);
            else if(await _sessionMgr.SessionDataExists() && !logged) ChangeScreen(ScreenId.BACKUP_LOGIN);
            else ChangeScreen(ScreenId.LOGIN);

        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            _logger.Info("settingsButton clicked");
            ChangeScreen(ScreenId.SETTINGS);
        }


        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            _logger.Info("sent application to the foreground");
            _hidden = false;
            Show();
            notifyIcon.Visible = false;
        }

       
    }
}