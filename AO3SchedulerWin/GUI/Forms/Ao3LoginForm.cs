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

        public async Task<bool> TryLogin()
        {

            //It is important to clear all the cookies, otherwise
            //AO3 will try to redirect us to the dashboard.
            Ao3HttpClient.Instance.ClearAllCookies();
            
            var loginPageReq = await Ao3HttpClient.Instance.Client.GetAsync("users/login/");
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(await loginPageReq.Content.ReadAsStringAsync());

            var csrfNode = htmlDoc.DocumentNode.SelectSingleNode("//meta[@name='csrf-token']");
            if (csrfNode != null)
            {
                string csrfToken = csrfNode.GetAttributeValue("content", "");
                if (string.IsNullOrEmpty(csrfToken))
                {
                    logger.Error("csrf token was empty");
                    MessageBox.Show("csrf token was empty");
                    return false;
                }

                var loginFormData = new Dictionary<string, string>
                {
                    { "authenticity_token", csrfToken },
                    { "user[login]", "drewitwrites@proton.me" },
                    { "user[password]", "p6A9jDvLEE4Uog" },
                    { "user[remember_me]", "1" },
                    { "commit", "Log in" }
                };


                var loginFormReq = await Ao3HttpClient.Instance.Client.PostAsync(
                    "users/login/", 
                    new FormUrlEncodedContent(loginFormData)
                );

                return loginFormReq.StatusCode == System.Net.HttpStatusCode.Redirect;
                
                
            }

            return false;


        }

     
        private async void loginButton_Click(object sender, EventArgs e)
        {
            loginButton.Enabled = false;
            await TryLogin();
            loginButton.Enabled = true;
        }
    }
}
