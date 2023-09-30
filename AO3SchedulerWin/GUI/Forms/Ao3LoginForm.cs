using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using AO3SchedulerWin.Models.AuthorModels;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Controllers.AuthorControllers;
using AO3SchedulerWin.AO3;

namespace AO3SchedulerWin.GUI.Forms
{
    public partial class Ao3LoginForm : Form
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Ao3Session _session;
        private IAuthorController _authorController;
        private int? _preloadId;
        public Ao3LoginForm(IAuthorModel authorModel, ref Ao3Session session, int? preloadId)
        {
            InitializeComponent();
            _authorController = new AuthorFormController(
                authorModel,
                userTextBox,
                passwordTextbox,
                preloadId);
            _session = session;
            _preloadId = preloadId;
            _authorController.UpdateViews();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                loginButton.Enabled = false;
                bool loginSucccess = await _session.TryLogin(userTextBox.Text, passwordTextbox.Text);
                loginButton.Enabled = true;
                if (!loginSucccess)
                {
                    MessageBox.Show(
                        "Invalid username/password",
                        "Login Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                
                Author author = await _session.GetAuthor();
                if (_preloadId.HasValue) _authorController.UpdateAuthor(author.Id, author);
                else _authorController.RegisterAuthor(author);
                _authorController.SetActiveAuthor(author.Id);
                Close();
               
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Network Error",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }catch(Ao3GenericException ex)
            {
                MessageBox.Show(
                        ex.Message,
                        "AO3 Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }

        }

        private void loginButton_EnabledChanged(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (!button.Enabled) loginButton.BackColor = Color.Gray;
            else loginButton.BackColor = Color.FromArgb(153, 0, 0); 
        }
    }
}
