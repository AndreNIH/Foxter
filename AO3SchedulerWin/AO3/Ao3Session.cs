using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AO3SchedulerWin.AO3
{
    public class Ao3Session
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private HttpClient _httpClient;
        public CookieContainer SessionCookies { get; private set; }
        public int Id { get; private set; }
        public string User { get; private set; }
        public bool Autenticated { get; private set; }

        
        private async Task<int> GetUserId()
        {
            var rootDoc = new HtmlAgilityPack.HtmlDocument();
            rootDoc.LoadHtml(await _httpClient.GetStringAsync($"users/{User}/profile"));
            var userIdNode = rootDoc.DocumentNode.SelectSingleNode("//input[@id='subscription_subscribable_id'][1]/@value");
            if(userIdNode != null)
            {
                string id = userIdNode.GetAttributeValue("value", null); 
                if(id == null) throw new Ao3GenericException("Could not read user id from the page");
                return int.Parse(id);
            }
            else
            {
                throw new Ao3GenericException("Could not read user id from the page");

            }
        }
        
        public void Reset()
        {
            SessionCookies = new CookieContainer();
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                CookieContainer = SessionCookies,
            };

            var uri = new Uri("https://archiveofourown.org/");
            _httpClient = new HttpClient(handler) { BaseAddress = uri };
            _logger.Info("Resetted Ao3Session object");
        }

        public async Task<bool> Login(string user, string password) {
            _logger.Info($"Logging in as '{user}'");
            
            //It is important to clear all the cookies, otherwise
            //AO3 will try to redirect us to the dashboard if we
            //are already logged in.
            Reset();


            //Load the CSRF token
            var rootDoc = new HtmlAgilityPack.HtmlDocument(); 
            var rawLoginPage = await _httpClient.GetStringAsync("users/login");
            rootDoc.LoadHtml(rawLoginPage);
            var csrfNode = rootDoc.DocumentNode.SelectSingleNode("//meta[@name='csrf-token']");
            if(csrfNode == null)
            {
                _logger.Warn("CSRF token missing from response");
                throw new Ao3GenericException("Missing authenticity token."); ;
            }
           string csrfToken = csrfNode.GetAttributeValue("content", "");

            //Perform login
            var loginFormData = new Dictionary<string, string>
            {
                { "authenticity_token", csrfToken },
                { "user[login]", user },
                { "user[password]", password },
                { "user[remember_me]", "1" },
                { "commit", "Log in" }
            };

            var form = new FormUrlEncodedContent(loginFormData);
            var loginRequest = await _httpClient.PostAsync("users/login", form);
            bool authenticated = loginRequest.StatusCode == HttpStatusCode.Redirect;
            this.Autenticated = authenticated;
            if(authenticated) {
                _logger.Info("Login attempt was successful successful");
                string userLinkMatchExpression = @"<a href=""https://archiveofourown\.org/users/(?<Username>[^""]+)""";
                var userLinkMatch = Regex.Match(await loginRequest.Content.ReadAsStringAsync(), userLinkMatchExpression);
                User = userLinkMatch.Groups["Username"].Value;
                Id = await GetUserId();
                return true;
            }
            else
            {
                _logger.Info("Login attempt failed");
                return false;
            }


        }


        
    }
}
