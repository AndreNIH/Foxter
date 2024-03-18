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

namespace AO3SchedulerWin.GUI.Screens
{
    public partial class SettingsScreen : Form
    {
        private static readonly string winServiceName = "AO3UploadService";
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public SettingsScreen()
        {
            InitializeComponent();
        }

        string GetServiceStatus(string serviceName)
        {

            ServiceController sc = new ServiceController(serviceName);

            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    return "Running";
                case ServiceControllerStatus.Stopped:
                    return "Stopped";
                case ServiceControllerStatus.Paused:
                    return "Paused";
                case ServiceControllerStatus.StopPending:
                    return "Stopping";
                case ServiceControllerStatus.StartPending:
                    return "Starting";
                default:
                    return "Status Changing";
            }
        }

        private void UpdateStatusLable()
        {
            try
            {
                statusLabel.Text = GetServiceStatus(winServiceName);
            }
            catch (InvalidOperationException)
            {
                statusLabel.Text = "Unavailable";
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateStatusLable();

        }

        private void serviceQueryTimer_Tick(object sender, EventArgs e)
        {
            UpdateStatusLable();
        }

        private void startServiceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                var sc = new ServiceController(winServiceName);
                var status = sc.Status;
                if (status == ServiceControllerStatus.Stopped || status == ServiceControllerStatus.StopPending)
                {
                    _logger.Info("starting service");
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = $"cmd.exe",
                        Arguments = $"/c sc.exe start \"{winServiceName}\"",
                        RedirectStandardOutput = false,
                        UseShellExecute = true,
                        CreateNoWindow = false,
                        Verb="runas"
                    };
                    process.StartInfo = startInfo;
                    process.Start();

                }
                else
                {
                    _logger.Warn($"attempted to start a service in an invalid state. current state={status.ToString()}");
                }
            }catch (InvalidOperationException ex)
            {
                _logger.Warn("failed to start service: " + ex.Message);
            }
        }

        private void stopServiceBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _logger.Info("stopping service");
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = $"cmd.exe",
                    Arguments = $"/c sc.exe stop \"{winServiceName}\"",
                    RedirectStandardOutput = false,
                    UseShellExecute = true,
                    CreateNoWindow = false,
                    Verb = "runas"
                };
                process.StartInfo = startInfo;
                process.Start();


            }
            catch (InvalidOperationException ex)
            {
                _logger.Warn("failed to stop service: " + ex.Message);
            }
        }
    }
}
