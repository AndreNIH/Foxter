﻿using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Factories;
using AO3SchedulerWin.Models.Base;
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
                _logger.Info("No configuration file was found. Falling back on default settings...");
                return new LocalAppServiceFactory();
            }
            catch (IOException)
            {
                _logger.Info("I/O error when attempting to read configuration file. Falling back on default settings...");
                return new LocalAppServiceFactory();
            }
        }
        
        
        protected async override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            var factory = this.CreateAppServiceFactory();
            var authorModel = factory.CreateAuthorModel();
            var author = await authorModel.Get();
            var session = new Ao3Session();
            if( author != null)
            {
                try
                {
                    bool success = await session.Login(author.Name, author.Password);
                    if (!success)
                    {
                        _logger.Info($"{author.Name} login failure. Removing author from database");
                        await authorModel.Delete();
                    }
                }
                catch (Ao3GenericException ex)
                {
                    _logger.Error(ex.Message);
                    Close();
                }
                catch (HttpRequestException ex)
                {
                    _logger.Warn(ex.Message);
                    MessageBox.Show(
                            ex.Message,
                            "Connection Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                            );
                }
            }

            var form = new MainForm(factory, session);
            form.Show();
            this.Hide();


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
