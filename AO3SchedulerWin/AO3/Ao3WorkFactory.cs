using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.AO3
{
    internal class Ao3WorkFactory
    {
        #pragma warning disable CS8602 // Dereference of a possibly null reference.
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #pragma warning restore CS8602 // Dereference of a possibly null reference.
        private Ao3Session _session;
        private HttpClient _httpClient;

        public async Task<Ao3Work> CreateWorkFromId(int id)
        {
            var worksPage = await _httpClient.GetAsync($"/works/{id}");
            if (!worksPage.IsSuccessStatusCode)
            {
                string exceptMsg = $"Couldnt't find work '{id}' in the archive";
                throw new Ao3NotFoundException(exceptMsg);
            }

            string rawDoc = await worksPage.Content.ReadAsStringAsync();
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(rawDoc);

            var metaGroup = htmlDoc.DocumentNode.SelectSingleNode("//dl[@class='work meta group']");
            if (metaGroup == null)
            {
                string exceptMsg = $"The work '{id}' is part of a private collection";
                throw new Ao3ForbiddenException(exceptMsg);
            }

            var titleNode = htmlDoc.DocumentNode.SelectSingleNode("//h2[@class='title heading'][1]/text()[1]");
            if (titleNode == null)
            {
                string exceptMsg = "Title heading locator found no matches";
                throw new Ao3GenericException(exceptMsg);
            }

            var work = new Ao3Work();
            work.WorkTitle = titleNode.InnerText;
            work.WorkId = id;
            return work;
        }
        
        public Ao3WorkFactory(Ao3Session session)
        {
            var handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                CookieContainer = session.SessionCookies,
            };

            var uri = new Uri("https://archiveofourown.org/");
            _httpClient = new HttpClient(handler) { BaseAddress = uri };
            _logger.Info("Created Ao3WorkFactory object");
        }
    }
}
