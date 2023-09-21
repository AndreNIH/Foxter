using AO3SchedulerWin.Factories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AO3SchedulerWin.GUI.Forms
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




        private IAppServiceFactory CreateAppServiceFactory()
        {
            try
            {
                var configFileStream = File.OpenRead("file.txt");
                using (var sr = new StreamReader(configFileStream))
                {
                    var appConfiguration = JsonConvert.DeserializeObject<AppConfiguration>(sr.ReadToEnd());
                    if (appConfiguration.ServiceType == ServiceType.kLocal)
                    {
                        return new LocalAppServiceFactory();
                    }
                    else if (appConfiguration.ServiceType == ServiceType.kRemote)
                    {

                    }
                    return null;
                }
            }
            catch (FileNotFoundException)
            {
                _logger.Info("No configuratio file was found. Falling back on default settings...");
                return new LocalAppServiceFactory();
            }
            catch (IOException)
            {
                _logger.Info("I/O error when attempting to read configuration file. Falling back on default settings...");
                return new LocalAppServiceFactory();
            }
        }


        protected async override void OnLoad(EventArgs e)
        {
            var factory = this.CreateAppServiceFactory();
            var authorModel = factory.CreateAuthorModel();
            try
            {
                var session = factory.GetSession();
                bool success = await session.RestoreCookiesFromDisk(authorModel);

                //Cookies could not be loaded
                //Attempt to log in the user
                if (!success)
                {
                    var author = authorModel.GetActiveAuthor();
                    if (author != null)
                    {
                        success = await session.TryLogin(author.Name, author.Password);
                        if (!success) authorModel.SetActiveUser(-1); ;

                    }

                }
            }
            catch(HttpRequestException ex)
            {
                MessageBox.Show(
                            "Verify you are connected to the internet: " + ex.Message,
                            "Network Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                            );
            }

            var form = new MainForm(factory);
            Hide();
            form.Show();


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
