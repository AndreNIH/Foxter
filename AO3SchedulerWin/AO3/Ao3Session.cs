using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AO3SchedulerWin.AO3
{
    public class Ao3Session
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private HttpClient _httpClient;
        public CookieContainer SessionCookies { get; private set; }
        public string User { get; private set; }
        public bool Autenticated { get; private set; }

        private void Reset()
        {
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
