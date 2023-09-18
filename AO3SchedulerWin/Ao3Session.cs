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
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace AO3SchedulerWin
{
    
    public class Ao3Session
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _appStorePath;
        public HttpClient httpClient;
        public HttpClient httpClientRedirect;
        private CookieContainer _cookieContainer;
        private string _username = "";
        private string _password = "";
        
        private bool authenticated = false;


        public async Task<bool> RestoreCookiesFromDisk()
        {
            try
            {
                using (var fs = File.Open(_appStorePath + "/cookiejar.json", FileMode.Open))
                {
                    _logger.Info("cookiejar.json file located");
                    using (var sr = new StreamReader(fs))
                    {
                        var cookies = JsonConvert.DeserializeObject<List<Cookie>>(await sr.ReadToEndAsync());
                        foreach(var c in cookies)
                        {
                            _cookieContainer.Add(httpClient.BaseAddress, c);
                        }
                        


                    }
                    //Cookies are loaded. Now we need the user's username
                    _logger.Info("Loaded cookies cookies");
                    
                    //Fetch the USERNAME from from the current session
                    var username = await FetchUsernameFromSession();
                    if(username != null)
                    {
                        _logger.Info("Cookies hold valid session data. Attemping to create Author object");
                        //Create an Auhtor from the USERNAME
                        var author = await GetAuthorObjectFromUser(username);
                        _username = author.Name;
                        _password = author.Password;
                        _logger.Info("Session restored successfully");
                        return true;

                    }
                    else
                    {
                        _logger.Warn("Could not fetch username from session cookies.");
                    }
        
                }
            }catch(JsonException ex)
            {
                _logger.Warn("Could not parse cookie store: " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                _logger.Warn("Could not restore previous session from cookies. " + ex.Message);
            }catch(Exception ex)
            {
                _logger.Warn(ex);
            }
            return false;
        }

        public async Task<bool> WriteCookiesToDisk()
        {
            try
            {
                _logger.Info("Writing cookies to disk");
                using (var fs = File.Open(_appStorePath + "/cookiejar.json", FileMode.Create))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        var cookieCollection = _cookieContainer.GetAllCookies();
                        await sw.WriteAsync(JsonConvert.SerializeObject(cookieCollection));
                        _logger.Info("Succesfully stored data in cookiejar.json");
                        return true;
                    }
                }
            }catch (Exception ex)
            {
                _logger.Warn("Could not write cookies to disk: " + ex.Message);
            }
            return false; 
        }

        private async Task<string?> FetchUsernameFromSession()
        {
            try
            {
                var loginPageReq = await httpClient.GetAsync("users/login/");
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(await loginPageReq.Content.ReadAsStringAsync());
                var csrfNode = htmlDoc.DocumentNode.SelectSingleNode("//meta[@name='csrf-token']");

                string pattern = @"<a href=""https://archiveofourown\.org/users/(?<Username>[^""]+)""";
                string userFromRedirect = await loginPageReq.Content.ReadAsStringAsync();
                Match userMatch = Regex.Match(userFromRedirect, pattern);
                if (userMatch.Success) return userMatch.Groups["Username"].Value;
            }catch(HttpRequestException ex)
            {
                _logger.Error(ex.Message);
            }
            return null;
        }
        
        private async Task<bool> TryLogin(string user, string password)
        {

            _logger.Info($"Trying to log in. User: {user}");

            //It is important to clear all the cookies, otherwise
            //AO3 will try to redirect us to the dashboard if we
            //are already logged in.
            _cookieContainer.GetAllCookies().Clear();

            var loginPageReq = await httpClient.GetAsync("users/login/");
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
                    { "user[login]", user },
                    { "user[password]", password },
                    { "user[remember_me]", "1" },
                    { "commit", "Log in" }
                };


                var loginFormReq = await httpClient.PostAsync(
                    "users/login/",
                    new FormUrlEncodedContent(loginFormData)
                );


                string userFromRedirect = await loginFormReq.Content.ReadAsStringAsync();
                bool authenticated = loginFormReq.StatusCode == System.Net.HttpStatusCode.Redirect;

                if (authenticated)
                {
                    string pattern = @"<a href=""https://archiveofourown\.org/users/(?<Username>[^""]+)""";
                    Match userMatch = Regex.Match(userFromRedirect, pattern);
                    if (userMatch.Success)
                    {
                        _username = userMatch.Groups["Username"].Value;
                        _password = password;
                    }
                    else
                    {
                        throw new Ao3GenericException("Could not extract username");
                    }
                }
                _logger.Info("Login " + (authenticated ? "successful" : "failed"));


                await WriteCookiesToDisk();
                return authenticated;
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
        public async Task<IEnumerable<Ao3Work>> GetAllAuthorWorks()
        {
            _username = "J_Shute";
            HttpResponseMessage worksBody = await httpClient.GetAsync($"users/{_username}/works/");
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(await worksBody.Content.ReadAsStringAsync());

            HtmlNodeCollection userWorks = htmlDoc.DocumentNode.SelectNodes("//li[contains(@class, 'blurb')]/descendant::a[1]");
            var getUserWorksTasks = new List<Task<Ao3Work>>();
            foreach(var work in userWorks)
            {
                try
                {
                    string tempWorkId = work.GetAttributeValue("href", null);
                    if (tempWorkId == null)
                    {
                        throw new Ao3GenericException("Missing authenticity token."); ;
                    }
                    int workId = Int32.Parse(tempWorkId.Substring(7));
                    getUserWorksTasks.Add(Ao3Work.GetWorkFromId(this, workId));
                }catch(FormatException)
                {
                    _logger.Error("WorkId contains an invalid value: " + work.GetAttributeValue("href", ""));
                }catch(Ao3GenericException ex)
                {
                    _logger.Error(ex.Message);
                }
                
            }
            return await Task.WhenAll(getUserWorksTasks);
        }


        public async Task<Author> GetAuthorObjectFromUser(string username)
        {
            HttpResponseMessage profileBody = await httpClient.GetAsync($"users/{username}/profile");
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(await profileBody.Content.ReadAsStringAsync());
            HtmlNode userId = htmlDoc.DocumentNode.SelectSingleNode("//input[@id='subscription_subscribable_id'][1]/@value");
            if (userId == null) throw new Ao3GenericException("Could not extract UserId");
            try
            {
                var author = new Author();
                author.Id = Int32.Parse(userId.GetAttributeValue("value", null));
                author.Name = _username;
                author.Password = _password;
                return author;
            }
            catch (FormatException)
            {
                throw new Ao3GenericException("UserId contains an invalid value");
            }
        }

        public async Task<Author> GetAuthor()
        {
            return await GetAuthorObjectFromUser(_username);
        }

        public static async Task<Ao3Session?> RestoreSession()
        {
            var session = new Ao3Session();
            return await session.RestoreCookiesFromDisk()
                ? session
                : null;
        }

        private Ao3Session()
        {

            var proxy = new WebProxy
            {
                Address = new Uri($"http://127.0.0.1:8080"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
            };


            _appStorePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "AO3S"
            );

            _cookieContainer = new CookieContainer();
            var clientHandler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                CookieContainer = _cookieContainer,
                UseProxy = true,
                Proxy = proxy

            };

            var clientHandlerNoRedirect = new HttpClientHandler()
            {
                AllowAutoRedirect = true,
                CookieContainer = _cookieContainer,
                UseProxy = true,
                Proxy = proxy
            };

            var uri = new Uri("https://archiveofourown.org/");
            clientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            clientHandlerNoRedirect.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            httpClient = new HttpClient(clientHandler) { BaseAddress = uri };
            httpClientRedirect = new HttpClient(clientHandlerNoRedirect) { BaseAddress= uri };
        }

    }
}
