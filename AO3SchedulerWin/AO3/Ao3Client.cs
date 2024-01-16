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
        private HttpClient _httpClient;
        private Ao3Session _session;
        private Ao3WorkFactory _workFactory;
        public Ao3Client(Ao3Session session)
        {
            _session = session;
            if (!session.Autenticated) {
                throw new Ao3GenericException("Session not authenticated");
            }

            //No-redirect client
            var uri = new Uri("https://archiveofourown.org");
            var clientHandler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                CookieContainer = session.SessionCookies
            };
            _httpClient = new HttpClient() { BaseAddress = uri };
            _workFactory = new Ao3WorkFactory(_session); //No DI here

        }

        public async Task<List<Ao3Work>> GetAllWorks()
        {
            var worksList = new List<Ao3Work>();
            for(int pageNumber = 1; ; pageNumber++)
            {
                _logger.Info($"Fetching all works on page {pageNumber} for user {_session.User}");
                var rawDoc = await _httpClient.GetStringAsync($"users/{_session.User}/works?page={pageNumber}");
                var docRoot = new HtmlAgilityPack.HtmlDocument();
                docRoot.LoadHtml(rawDoc);
                var userWorks = docRoot.DocumentNode.SelectNodes("//li[contains(@class, 'blurb')]/descendant::a[1]");
                foreach(var work in userWorks)
                {
                    string workHref = work.GetAttributeValue("href", null);
                    if (workHref == null) throw new Ao3GenericException($"Could not extract href tag from {work.OuterHtml}");
                    int workId = int.Parse(workHref.Substring(7)); //remove "/works/" from <a href=...>
                    worksList.Add(await _workFactory.CreateWorkFromId(workId));
                }

                //Check for pagination. Exit loop if there is no NEXT button
                var navNode = docRoot.DocumentNode.SelectSingleNode("//ol[@class='pagination actions'][1]/li[@class='next'][1]/@class");
                if (navNode != null)
                {
                    var nextNode = navNode.SelectSingleNode("//li[@class='next'][1]/a[1]");
                    if (nextNode == null) break;
                }
                else
                {
                    break;
                }

                //Delay to avoid getting rate limited
                await Task.Delay(500);
            }
            return worksList;
        }

    }
}
