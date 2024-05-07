using Foxter.GUI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Foxter.GUI.Screens
{
    public partial class BackupLoginScreen : Form
    {
        private System.Timers.Timer _timer;
        private DateTime _lastAttempt;
        private SessionManager _sessionManager;
        private IScreenUpdater _screenUpdater;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()!.DeclaringType);
        public BackupLoginScreen(SessionManager sessionManager, IScreenUpdater screen)
        {
            InitializeComponent();
            _sessionManager = sessionManager;
            _screenUpdater = screen;
            _lastAttempt = DateTime.Now;
            _timer = new System.Timers.Timer(100);
            _timer.AutoReset = true;
            _timer.Elapsed += timer_Elapsed;
            _timer.Start();
            _logger.Info("started session login timer");
        }

        private void timer_Elapsed(object? sender, ElapsedEventArgs e)
        {

            Invoke((MethodInvoker)async delegate
            {
                long retryThreshold = 10;
                var delta = (DateTime.Now - _lastAttempt);
                retryLabel.Text = $"Retrying in {(TimeSpan.FromSeconds(retryThreshold) - delta).Seconds + 1} seconds";
                if (delta >= TimeSpan.FromSeconds(retryThreshold))
                {
                    _lastAttempt = DateTime.Now;
                    _logger.Info("retyring login");
                    try
                    {
                        if(await _sessionManager.RestorePreviousSession())
                        {
                            _screenUpdater.ChangeScreen(ScreenId.MAIN);
                        }
                    }catch(HttpRequestException exception)
                    {
                        _logger.Error("failed to restore session: " + exception.Message);
                    }
                }
            });
        }

        protected override void OnClosed(EventArgs e)
        {
            _logger.Info("stopped session login timer");
            _timer.Stop();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void cancelButton_Click(object sender, EventArgs e)
        {
            await _sessionManager.DeleteSession();
            _screenUpdater.ChangeScreen(ScreenId.LOGIN);
        }
    }
}
