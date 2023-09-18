using AO3SchedulerWin.Forms;
using AO3SchedulerWin.GUI.Screens;
using AO3SchedulerWin.Models.AuthorModels;
using System.Runtime.InteropServices;

namespace AO3SchedulerWin
{
    public partial class MainForm : Form
    {
        //WinAPI DLL Imports
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwndm, int msg, int wParam, int lParam);
        //End of external DLL imports

        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IAuthorModel _authorModel = new AuthorLocalModel();
        private Ao3Session _session;
        public MainForm()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            var activeAuthor = _authorModel.GetActiveAuthor();
            Form nextScreen = activeAuthor == null
                ? new NoActiveUserScreen()
                : new HomeScreen();

            

            SetMainContent(nextScreen);
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
            Application.Exit();
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

        private Form _activeForm;

        //Sidebar Buttons
        private void homeButton_Click(object sender, EventArgs e)
        {

            Form nextScreen = _authorModel.GetActiveAuthor() == null
                ? new NoActiveUserScreen()
                : new HomeScreen();
            SetMainContent(nextScreen);
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            Form nextScreen = _authorModel.GetActiveAuthor() == null
                ? new NoActiveUserScreen()
                : new SchedulerScreen(_session);
            SetMainContent(nextScreen);
        }

        private void accountsButton_Click(object sender, EventArgs e)
        {
            SetMainContent(new AuthorsScreen());
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {

        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            var activeAuthor = _authorModel.GetActiveAuthor();
            if (activeAuthor != null)
            {
                //Attempt to restore session
                var restoredSession = await Ao3Session.RestoreSession(_authorModel);
                
                //Cookie session restoration failed. Attempt to re-log into user account
                if(restoredSession == null)
                {
                    logger.Info($"Re-logging into  '{activeAuthor.Name}'");
                    _session = await Ao3Session.CreateSession(activeAuthor.Name, activeAuthor.Password);
                    //Re-login failed
                    if( _session == null)
                    {
                        logger.Warn($"Failed to log in to '{activeAuthor.Name}'");
                        _authorModel.SetActiveUser(-1);
                    }
                }
                else
                {
                    //Restore session
                    _session = restoredSession;
                }

            }
            else
            {
                logger.Info("No active users in model. Skipping session loading");
            }

        }
    }
}