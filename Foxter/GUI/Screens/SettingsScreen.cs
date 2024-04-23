using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Diagnostics;
using Foxter.Settings;
using Microsoft.Win32;

namespace Foxter.GUI.Screens
{
    public partial class SettingsScreen : Form
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public SettingsScreen()
        {
            InitializeComponent();
        }

        //Event Handlers
        private void RunAtStartupCheckbox_CheckedChanged(object? sender, EventArgs e)
        {
            var obj = (CheckBox)sender!;
            SettingsManager.Get.Configuration.runAtStartup = obj.Checked;
            SettingsManager.Get.Persist();
            var regKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true)!;
            if (obj.Checked)
            {
                regKey.SetValue("Foxter", $"\"{Application.ExecutablePath}\" --launch");
                _logger.Info("added startup registry key");
            }
            else
            {
                regKey.DeleteValue("Foxter");
                _logger.Info("removed startup registry key");
            }
        }

        private void SendToTrayCheckbox_CheckedChanged(object? sender, EventArgs e)
        {
            var obj = (CheckBox)sender!;
            SettingsManager.Get.Configuration.sendToTray = obj.Checked;
            SettingsManager.Get.Persist();
        }

        private void StartMinimizedCheckbox_CheckedChanged(object? sender, EventArgs e)
        {
            var obj = (CheckBox)sender!;
            SettingsManager.Get.Configuration.startMinimized = obj.Checked;
            SettingsManager.Get.Persist();
        }


        //Load settings
        private void ReadSettings()
        {
            runAtStartupCheckbox.Checked = SettingsManager.Get.Configuration.runAtStartup;
            startMinimizedCheckbox.Checked = SettingsManager.Get.Configuration.startMinimized;
            sendToTrayCheckbox.Checked = SettingsManager.Get.Configuration.sendToTray;
        }

        //Register event handlers
        private void RegisterHandlers()
        {
            runAtStartupCheckbox.CheckedChanged += RunAtStartupCheckbox_CheckedChanged;
            startMinimizedCheckbox.CheckedChanged += StartMinimizedCheckbox_CheckedChanged;
            sendToTrayCheckbox.CheckedChanged += SendToTrayCheckbox_CheckedChanged;
        }

        

        //OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ReadSettings();
            RegisterHandlers();

        }
    }
}
