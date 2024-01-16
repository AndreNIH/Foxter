using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Factories;
using AO3SchedulerWin.Forms;
using AO3SchedulerWin.GUI.Screens;
using AO3SchedulerWin.Models;
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
        private IAuthorModel _authorModel;
        private IChapterModel _chapterModel;
        private Ao3Session _session;

        public MainForm(IAppServiceFactory serviceFactory, Ao3Session session)
        {
            InitializeComponent();
            _authorModel = serviceFactory.CreateAuthorModel();
            _chapterModel = serviceFactory.CreateChapterModel();
            _session = session;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Form nextScene = _session.Autenticated
                ? new LoggedUserScreen()
                : new NoActiveUserScreen();

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

            /*Form nextScreen = _authorModel.GetActiveAuthor() == null
                ? new NoActiveUserScreen()
                : new HomeScreen();*/
            //SetMainContent(nextScreen);
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            /*
            Form nextScreen = _authorModel.GetActiveAuthor() == null
                ? new NoActiveUserScreen()
                : new SchedulerScreen(_session);*/
            //SetMainContent(nextScreen);
            SetMainContent(new SchedulerScreen(null));
        }

        private async void accountsButton_Click(object sender, EventArgs e)
        {

            //SetMainContent(new AuthorsScreen(ref _session));
            SetMainContent(new LoginScreen());


        }

        private void settingsButton_Click(object sender, EventArgs e)
        {

        }

        private async void MainForm_Load(object sender, EventArgs e)
        {


        }
    }
}