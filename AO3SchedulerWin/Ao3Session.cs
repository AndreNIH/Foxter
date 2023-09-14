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
using AO3SchedulerWin.Models;
using System.Text.RegularExpressions;

namespace AO3SchedulerWin
{
    
    internal class Ao3Session
    {
        private HttpClient _httpClient;
        private CookieContainer _cookieContainer;
        private string _username;
        private string _password;
        private bool Authenticated = false;

        private async Task<bool> TryLogin(string user, string password)
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
                    throw new Ao3GenericException("Missing authenticity token."); ;
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
                if (this.Authenticated)
                {
                    string pattern = @"<a href=""https://archiveofourown\.org/users/(?<Username>[^""]+)""";
                    Match userMatch = Regex.Match(await loginFormReq.Content.ReadAsStringAsync(), pattern);
                    if (userMatch.Success)
                    {
                        _username = userMatch.Groups["username"].Value;
                        _password = password;
                    }
                    else
                    {
                        throw new Ao3GenericException("Could not extract username");
                    }
                }
                return this.Authenticated;
            }

            return false;


        }
       

        public static async Task<Ao3Session?> CreateSession(string username, string password)
        {
            var session = new Ao3Session();
            return await session.TryLogin(username, password)
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
                    throw new Ao3GenericException("Missing authenticity token."); ;
                }
                int workId = Int32.Parse(tempWorkId.Substring(6));
                string workTitle = work.InnerHtml;
                storiesList.Add((workId, workTitle));
            }
            return storiesList;
        }

        public async Task<Author> GetAuthor()
        {
            HttpResponseMessage profileBody = await _httpClient.GetAsync($"users/{_username}/profile");
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(await profileBody.Content.ReadAsStringAsync());
            htmlDoc.DocumentNode.SelectSingleNode("//");
            

            return null;
        }

        public Ao3Session()
        {
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
