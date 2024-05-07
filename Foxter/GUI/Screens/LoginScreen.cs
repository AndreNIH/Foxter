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
        private bool _ignoreKeyboard;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()!.DeclaringType);

        public LoginScreen(SessionManager sessionManager, IAuthorModel authorModel, IScreenUpdater updater)
        {
            InitializeComponent();
            _sessionMgr = sessionManager;
            _updater = updater;
            _loggedAuthorController = new LoginAuthorController(authorModel);
            _ignoreKeyboard = false;

            userTextBox.KeyDown += UserTextBox_KeyDown;
            passwordTextBox.KeyDown += PasswordTextBox_KeyDown;
        }

        private async void PasswordTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !_ignoreKeyboard)
            {
                await DoLogin();
            }
        }

        private void UserTextBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) passwordTextBox.Focus();
        }

        private async Task<bool> SendLoginRequest()
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


        private async Task DoLogin()
        {
            loginButton.BackColor = Color.Gray;
            loginButton.Enabled = false;
            _ignoreKeyboard = true;
            bool success = await SendLoginRequest();
            loginButton.BackColor = Color.FromArgb(153, 0, 0);
            loginButton.Enabled = true;
            _ignoreKeyboard = false;

            if (!success)
            {
                MessageBox.Show("Incorrect password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _updater.ChangeScreen(ScreenId.MAIN);
            }
        }

     
        private async void loginButton_Click_1(object sender, EventArgs e)
        {

            await DoLogin();
        }




        //UI Elements
    }
}
