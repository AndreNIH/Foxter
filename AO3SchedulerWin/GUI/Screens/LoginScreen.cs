using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Controllers.AuthorControllers;
using AO3SchedulerWin.GUI.Forms;
using AO3SchedulerWin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AO3SchedulerWin.GUI.Screens
{
    public partial class LoginScreen : Form
    {
        private IAuthorController _loggedAuthorController;
        private Ao3Session _session;
        private IScreenUpdater _updater;

        public LoginScreen(ref Ao3Session client, IAuthorModel authorModel, IScreenUpdater updater)
        {
            _session = client;
            _updater = updater;
            _loggedAuthorController = new LoginAuthorController(authorModel);
            InitializeComponent();
        }

        private async Task<bool> DoLogin()
        {
            bool success = false;
            try
            {
                success = await _session.Login(userTextBox.Text.ToString(), passwordTextBox.Text.ToString());
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

            await _loggedAuthorController.UnregisterAuthor();
            loginButton.BackColor = Color.Gray;
            loginButton.Enabled = false;
            bool success = await DoLogin();
            loginButton.Enabled = true;
            loginButton.BackColor = Color.FromArgb(153, 0, 0);


            if (success)
            {
                await _loggedAuthorController.RegisterAuthor(new Models.Base.Author
                {
                    Id = _session.Id,
                    Name = _session.User,
                    Password = passwordTextBox.Text.ToString()
                });
                _updater.ChangeScreen(ScreenId.MAIN);
            }
            else
            {
                MessageBox.Show("Incorrect password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //UI Elements
    }
}
