using AO3SchedulerWin.Utils;
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

namespace AO3SchedulerWin.GUI.Forms
{
    public partial class Ao3LoginForm : Form
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IAuthorModel _authorModel;
        public Ao3LoginForm(IAuthorModel authorModel)
        {
            InitializeComponent();
            _authorModel = authorModel;
        }




        private async void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                loginButton.Enabled = false;
                Ao3Session? session = await Ao3Session.CreateSession(userTextBox.Text, passwordTextbox.Text);
                loginButton.Enabled = true;
                if (session == null)
                {
                    MessageBox.Show(
                        "Invalid username/password",
                        "Login Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                Author author = new Author();
                author.Name = userTextBox.Text;
                author.Password = passwordTextbox.Text;
                _authorModel.AddAuthor(author);
                this.Close();
               
            }
            catch (HttpRequestException ex)
            {

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
