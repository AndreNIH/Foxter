using AO3SchedulerWin.Utils;
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;

namespace AO3SchedulerWin
{
    
    class Ao3LoginException : Exception{}
    
    internal class Ao3Session
    {
        private HttpClient _httpClient;
        private CookieContainer _cookieContainer;
        private string _username;
        private string _password;
        private bool Authenticated = false;

        private async Task<bool> TryLogin()
        {

            //It is important to clear all the cookies, otherwise
            //AO3 will try to redirect us to the dashboard if we
            //are already logged in.
            _cookieContainer.GetAllCookies().Clear();

            var loginPageReq = await _httpClient.GetAsync("users/login/");
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(await loginPageReq.Content.ReadAsStringAsync());

            var csrfNode = htmlDoc.DocumentNode.SelectSingleNode("//meta[@name='csrf-token']");
            if (csrfNode != null)
            {
                string csrfToken = csrfNode.GetAttributeValue("content", "");
                if (string.IsNullOrEmpty(csrfToken))
                {
                    MessageBox.Show("csrf token was empty", "CSRF token error");
                    return false;
                }

                var loginFormData = new Dictionary<string, string>
                {
                    { "authenticity_token", csrfToken },
                    { "user[login]", _username },
                    { "user[password]", _password },
                    { "user[remember_me]", "1" },
                    { "commit", "Log in" }
                };


                var loginFormReq = await _httpClient.PostAsync(
                    "users/login/",
                    new FormUrlEncodedContent(loginFormData)
                );

                this.Authenticated = loginFormReq.StatusCode == System.Net.HttpStatusCode.Redirect;
                return this.Authenticated;
            }

            return false;


        }
       

        public static async Task<Ao3Session?> CreateSession(string username, string password)
        {
            var session = new Ao3Session(username, password);
            return await session.TryLogin()
                ? session
                : null;
        }

        //Return a list of tuples containing WorkId, WorkTitle
        public async Task<List<(int,string)>> GetAllAuthorStories()
        {
            HttpResponseMessage worksBody = await _httpClient.GetAsync($"users/{_username}/works/");
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(await worksBody.Content.ReadAsStringAsync());

            HtmlNodeCollection userWorks = htmlDoc.DocumentNode.SelectNodes("//li[contains(@class, 'blurb')]/descendant::a[1]");
            var storiesList = new List<(int, string)>();
            foreach(var work in userWorks)
            {
                string tempWorkId = work.GetAttributeValue("href",null); 
                if(tempWorkId == null)
                {
                    //log the error
                    return null;
                }
                int workId = Int32.Parse(tempWorkId.Substring(6));
                string workTitle = work.InnerHtml;
                storiesList.Add((workId, workTitle));
            }
            return storiesList;
        }

        public Ao3Session(string username, string password)
        {
            _username = username;
            _password = password;
            _cookieContainer = new CookieContainer();
            var clientHandler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                CookieContainer = _cookieContainer
                
            };

            _httpClient = new HttpClient(clientHandler);
            _httpClient.BaseAddress = new Uri("https://archiveofourown.org/");
        }

    }
}
