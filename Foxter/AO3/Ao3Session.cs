using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Foxter.AO3.Exceptions;
using static System.Windows.Forms.Design.AxImporter;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Foxter.AO3
{
    public class Ao3Session : ISession
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()!.DeclaringType);
        private HttpClient _httpClient;
        private CookieContainer _cookies;
        private bool _authenticated;
        private string _username;
        private int _userId;

        private async Task<(int,string)?> FetchIdAndUsername()
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            string username;
            int userId=0;
            string rawHtml = "";
            //Get username
            _logger.Info("retrieving username data. GET /");
            var page = await _httpClient.GetAsync("/");
            rawHtml = await page.Content.ReadAsStringAsync();
            doc.LoadHtml(rawHtml);
            
            string exp = "//nav[@id='greeting']//li[@class='dropdown'][1]/a";
            var userNode = doc.DocumentNode.SelectSingleNode(exp);
            if (userNode != null)
            {

                username = userNode.GetAttributeValue("href", null);
                if (username == null) {
                    _logger.Error("could not extract username because the corresponding menu item did not contain an href attribute");
                    return null;
                }
                username = username.Substring(7);
            }
            else
            {
                _logger.Warn("could not to obtain username: field not found");
                return null;
            }


            _logger.Info($"retrieving user ID data. GET /users/{username}/profile");
            page = await _httpClient.GetAsync($"users/{username}/profile");
            rawHtml = await page.Content.ReadAsStringAsync();
            doc.LoadHtml(rawHtml);
            var userIdNode = doc.DocumentNode.SelectSingleNode("//input[@id='subscription_subscribable_id']/@value");
            if (userIdNode == null || !int.TryParse(userIdNode.GetAttributeValue("value", ""), out userId))
            {
                _logger.Warn("could not to obtain id: field lookup failed");
                return null;
            }

            return (userId, username);

        }

        private async Task SetSessionIdentifiers()
        {
            var identifiers = await FetchIdAndUsername();
            if (identifiers != null)
            {
                var (id, username) = identifiers.Value;
                _userId = id;
                _username = username;
                _authenticated = true;

                _logger.Info($"set session identifiers to: username={_username}, userId={_userId}");
            }
            else
            {
                _logger.Error("failed to retrieve session identifiers");
                throw new Ao3GenericException("session values retrieval failed");
            }
        }


        public void Reset()
        {
            _cookies = new CookieContainer();
            _authenticated = false;
            _username = "";
            _userId = 0;
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                CookieContainer = _cookies,
                Proxy = new WebProxy()
                {
                    //Address = new("http://127.0.1:8080")
                }
                //,ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            

            var uri = new Uri("https://archiveofourown.org/");
            _httpClient = new HttpClient(handler) { BaseAddress = uri };
            _logger.Info("cleared session object data");
        }

        public async Task<bool> Login(string user, string password) {
            _logger.Info($"attempting to log in as '{user}'");
            
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
            
            if(authenticated) {
                await SetSessionIdentifiers();
                _authenticated = true;
                _logger.Info("login was sucessful");
                return true;
            }
            else
            {
                _logger.Info("login was unsuccesful");
                return false;
            }


        }

        public async Task<bool> LoadPreviousSession(string data)
        {

            _logger.Info("attempting to restore a previous session using session cookies");
            Reset();
            var collection = JsonSerializer.Deserialize<CookieCollection>(data);
            if (collection == null)
            {
                _logger.Warn($"failed to deserialize session cookies, raw data: {data}");
                return false;
            }
            
            _cookies.GetAllCookies().Clear();
            _cookies.Add(new Uri("https://archiveofourown.org"), collection);
            _logger.Info("session data decoded");
            try
            {
                await SetSessionIdentifiers();
                _authenticated = true;
                return true;
            }
            catch (Ao3GenericException)
            {
                _logger.Warn("session data exists and is well-formed, but it is no longer valid");
                return false;
            }
        }

        //Getters
        public CookieContainer GetCookies()
        {
            return _cookies;
        }

        public int GetId()
        {
            return _userId;
        }

        public string GetUser()
        {
            return _username;
        }

        public bool IsAuthenticated()
        {
            return _authenticated;
        }

        //ctor
        public Ao3Session()
        {

            _logger.Info("created new session object");
            _httpClient = new HttpClient();
            _cookies = new CookieContainer();
            _authenticated = false;
            _username = "";
            _userId = 0;
        }
    }
}
