using Foxter.AO3;
using Foxter.Controllers.AuthorControllers;
using Foxter.GUI.Forms;
using Foxter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foxter.GUI.Screens
{
    public partial class LoggedUserScreen : Form
    {
        private IAuthorController _authorDisplayController;
        private SessionManager _sessionMgr;
        private IScreenUpdater _updater;
        public LoggedUserScreen(SessionManager sessionMgr, IScreenUpdater updater)
        {
            InitializeComponent();
            _sessionMgr = sessionMgr;
            _updater = updater;
        }

        protected async override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            authorLabel.Text = _sessionMgr.GetExistingSession().GetUser();
        }

        private async void logoutButton_Click(object sender, EventArgs e)
        {
            await _sessionMgr.DeleteSession();
            _updater.ChangeScreen(ScreenId.LOGIN);
        }
    }
}
