using Foxter.AO3;
using Foxter.Factories;
using Foxter.Models.Base;
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

        private Ao3Session _session;
        private IAppServiceFactory _appServiceFactory;


        private IAppServiceFactory CreateAppServiceFactory()
        {
            try
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),"AO3S");
                var serviceFactory = new LocalAppServiceFactory(path);
                return serviceFactory;


            }catch(SqlException ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show("An error occured while accessing the database");
                
            }catch(UnauthorizedAccessException ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
            
            return null;

        }

        private async Task<Ao3Session?> CreateSession(Author author)
        {
            try
            {
                var session = new Ao3Session();
                bool success = await session.Login(author.Name, author.Password);
                if (success) return session;
                else return null;
            }
            catch(Ao3GenericException ex)
            {
                _logger.Error(ex.Message);
            }
            catch(HttpRequestException ex)
            {
                _logger.Warn(ex.Message);
                MessageBox.Show(
                        ex.Message,
                        "Connection Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                        );
            }
            return null;
        }
        
        private async Task InitializeApplication() {
            //Initialize settings
            if (!SettingsManager.Get.Load())
            {
                SettingsManager.Get.Persist();
            }
            
            _session = new Ao3Session();
            _appServiceFactory = CreateAppServiceFactory();
            
            //Theres no service factory
            //terminate the program
            if(_appServiceFactory == null){
                Application.Exit();
                return;
            }
            
            var authorModel = _appServiceFactory.CreateAuthorModel();
            var author = await authorModel.Get();
            //Theres no logged author
            //return early
            if(author == null)
            {
                return;
            }

            //Try to log in
            try
            {
                var newSession = await CreateSession(author);
                if (newSession == null)
                {
                    //Failed to log in
                    await authorModel.Delete();
                }
                else
                {
                    _session = newSession;
                }
            }catch(Ao3GenericException)
            {
                MessageBox.Show("An unknwon error occured", "Unknown Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(HttpRequestException ex)
            {
                _logger.Warn(ex.Message);
                MessageBox.Show(ex.Message,"Connection Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }
        
        protected override async  void OnShown(EventArgs e)
        {
            base.OnShown(e);
            await Task.Run(InitializeApplication);
            new MainForm(_appServiceFactory, _session).Show();
            Hide();
        }


        public AppLoaderForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
