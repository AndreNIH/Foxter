using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Net.Sockets;
using AO3SchedulerWin.Models.Base;

namespace AO3SchedulerWin.AO3
{

    public class Ao3Client
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _appStorePath;
        public HttpClient httpClient;
        public HttpClient httpClientRedirect;
        private CookieContainer _cookieContainer;
        private string _username = "";
        private string _password = "";

        private bool authenticated = false;

        //Cookies Read/Write methods
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
                        foreach (var c in cookies)
                        {
                            _cookieContainer.Add(httpClient.BaseAddress, c);
                        }
                    }
                    //Cookies are loaded. Now we need the user's username
                    _logger.Info("Loaded cookies cookies");

                    //Fetch the USERNAME from from the current session
                    var username = await FetchUsernameFromSession();
                    if (username != null)
                    {
                        _logger.Info($"Session corresponds to user '{username}'");
                        return false;
                        /*var restoredAuthor = authorModel.GetAllAuthors().Find(uname => uname.Name == username);
                        if (restoredAuthor != null)
                        {
                            _logger.Info("Session restored successfully");
                            _username = restoredAuthor.Name;
                            _password = restoredAuthor.Password;
                            return true;
                        }
                        else
                        {
                            _logger.Warn("Author isn't registed in the application database");
                        }
                        return false;*/
                    }
                    else
                    {
                        _logger.Warn("Could not fetch username from session cookies.");
                    }

                }
            }
            catch (JsonException ex)
            {
                _logger.Warn("Could not parse cookie store: " + ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                _logger.Warn("Could not restore previous session from cookies. " + ex.Message);
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
            }
            catch (Exception ex)
            {
                _logger.Warn("Could not write cookies to disk: " + ex.Message);
            }
            return false;
        }

        //Session Methods
        public async Task<bool> TryLogin(string user, string password)
        {


            _logger.Info($"Trying to log in. User: {user}");

            //It is important to clear all the cookies, otherwise
            //AO3 will try to redirect us to the dashboard if we
            //are already logged in.
            RefreshSession();

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
                bool authenticated = loginFormReq.StatusCode == HttpStatusCode.Redirect;

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
            else
            {
                _logger.Warn("csrf token missing");
                _logger.Debug(htmlDoc.Text);
            }


            return false;
        }


        private async Task<string?> FetchUsernameFromSession()
        {

            var loginPageReq = await httpClient.GetAsync("users/login/");
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(await loginPageReq.Content.ReadAsStringAsync());
            var csrfNode = htmlDoc.DocumentNode.SelectSingleNode("//meta[@name='csrf-token']");

            string pattern = @"<a href=""https://archiveofourown\.org/users/(?<Username>[^""]+)""";
            string userFromRedirect = await loginPageReq.Content.ReadAsStringAsync();
            Match userMatch = Regex.Match(userFromRedirect, pattern);
            if (userMatch.Success) return userMatch.Groups["Username"].Value;
            return null;
        }

        //Session Query Methods
        public async Task<IEnumerable<Ao3Work>> GetAllAuthorWorks()
        {
            var userWorksList = new List<Ao3Work>();
            for (int pageNumber = 1; ; pageNumber++)
            {

                _logger.Info($"Fetching all works on page {pageNumber} for user {_username}");
                HttpResponseMessage worksBody = await httpClient.GetAsync($"users/{_username}/works?page={pageNumber}");
                var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                htmlDoc.LoadHtml(await worksBody.Content.ReadAsStringAsync());

                HtmlNodeCollection userWorks = htmlDoc.DocumentNode.SelectNodes("//li[contains(@class, 'blurb')]/descendant::a[1]");
                foreach (var work in userWorks)
                {
                    try
                    {
                        string tempWorkId = work.GetAttributeValue("href", null);
                        if (tempWorkId == null)
                        {
                            throw new Ao3GenericException("Missing authenticity token."); ;
                        }
                        int workId = int.Parse(tempWorkId.Substring(7));
                        string title = work.InnerText;
                        _logger.Info("Creating Ao3Work object for " + workId);
                        userWorksList.Add(Ao3Work.CreateWork(this, workId, title));
                    }
                    catch (FormatException)
                    {
                        _logger.Error("WorkId contains an invalid value: " + work.GetAttributeValue("href", ""));
                    }
                    catch (Ao3GenericException ex)
                    {
                        _logger.Error(ex.Message);
                    }


                }

                //Check for pagination. Exit loop if there is no NEXT button
                HtmlNode navNode = htmlDoc.DocumentNode.SelectSingleNode("//ol[@class='pagination actions'][1]/li[@class='next'][1]/@class");
                if (navNode != null)
                {
                    HtmlNode nextNode = navNode.SelectSingleNode("//li[@class='next'][1]/a[1]");
                    if (nextNode == null) break;
                }
                else
                {
                    break;
                }


                //Delay to avoid getting rate limited
                await Task.Delay(500);
            }
            return userWorksList;
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
                author.Id = int.Parse(userId.GetAttributeValue("value", null));
                author.Name = _username;
                author.Password = _password;
                return author;
            }
            catch (FormatException)
            {
                throw new Ao3GenericException("UserId contains an invalid value");
            }
            catch (HttpRequestException ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show(ex.Message, "Request Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SocketException ex)
            {
                _logger.Error(ex.Message);
                MessageBox.Show(ex.Message, "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public async Task<Author> GetAuthor()
        {
            return await GetAuthorObjectFromUser(_username);
        }

        //Session Creation
        private void RefreshSession()
        {
            var proxy = new WebProxy
            {
                Address = new Uri($"http://127.0.0.1:8080"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
            };




            bool useProxy = false;
            _cookieContainer = new CookieContainer();
            var clientHandler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                CookieContainer = _cookieContainer,
                UseProxy = useProxy

            };

            var clientHandlerNoRedirect = new HttpClientHandler()
            {
                AllowAutoRedirect = true,
                CookieContainer = _cookieContainer,
                UseProxy = useProxy
            };

            clientHandler.Proxy = proxy;
            clientHandlerNoRedirect.Proxy = proxy;

            var uri = new Uri("https://archiveofourown.org/");
            clientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            clientHandlerNoRedirect.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            httpClient = new HttpClient(clientHandler) { BaseAddress = uri };
            httpClientRedirect = new HttpClient(clientHandlerNoRedirect) { BaseAddress = uri };
            _logger.Info("Created new AO3 Session");
        }

        public Ao3Client()
        {

            _appStorePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "AO3S"
            );
            RefreshSession();
        }

    }
}
