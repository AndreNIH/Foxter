using Foxter.AO3.Exceptions;
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
    public partial class LoginScreen : Form
    {
        private IAuthorController _loggedAuthorController;
        private SessionManager _sessionMgr;
        private IScreenUpdater _updater;

        public LoginScreen(SessionManager sessionManager, IAuthorModel authorModel, IScreenUpdater updater)
        {
            _sessionMgr = sessionManager;
            _updater = updater;
            _loggedAuthorController = new LoginAuthorController(authorModel);
            InitializeComponent();
        }

        private async Task<bool> DoLogin()
        {
            bool success = false;
            try
            {
                success = await _sessionMgr.CreateNewSession(userTextBox.Text.ToString(), passwordTextBox.Text.ToString());
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Request Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }
            catch (Ao3GenericException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            return success;
        }

        private async void loginButton_Click_1(object sender, EventArgs e)
        {

            loginButton.BackColor = Color.Gray;
            loginButton.Enabled = false;
            bool success = await DoLogin();
            loginButton.Enabled = true;
            loginButton.BackColor = Color.FromArgb(153, 0, 0);
            
            if (!success)
            {
                MessageBox.Show("Incorrect password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _updater.ChangeScreen(ScreenId.MAIN);
            }
        }


        //UI Elements
    }
}
