using Foxter.AO3;
using Foxter.Models.Base;
using Foxter.Providers;
using Foxter.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxter.GUI.Forms
{

    public partial class AppLoaderForm : Form
    {

        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(AppLoaderForm));
        //WinAPI DLL Imports
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwndm, int msg, int wParam, int lParam);
        //End of external DLL imports
        SessionManager _sessionMgr;
        IDatabaseProvider _dbProvider;


        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //LoadApplicationSettings();
            
        }
        
        protected override async  void OnShown(EventArgs e)
        {
            base.OnShown(e);
            await Task.Run(_sessionMgr.RestorePreviousSession);
            Hide();
            new MainForm(_dbProvider, _sessionMgr).Show();
        }


        public AppLoaderForm(IDatabaseProvider dbProvider, SessionManager sessionManager)
        {
            _dbProvider = dbProvider;
            _sessionMgr = sessionManager;
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
