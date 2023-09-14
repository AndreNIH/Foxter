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

namespace AO3SchedulerWin.GUI.Forms
{
    public partial class Ao3LoginForm : Form
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Ao3LoginForm()
        {
            InitializeComponent();
        }

        


        private async void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                loginButton.Enabled = false;
                Ao3Session? session = await Ao3Session.CreateSession(userTextBox.Text, passwordTextbox.Text);
                if(session == null)
                {
                    MessageBox.Show(
                        "Invalid username/password", 
                        "Login Error", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
                }
                loginButton.Enabled = true;
            }
            catch (HttpRequestException ex) 
            { 
            
            }
            
        }
    }
}
