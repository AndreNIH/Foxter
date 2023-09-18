using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace AO3SchedulerWin
{
    public class Ao3Work
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Ao3Session _session;
        private string _workName;
        private int _workId;


        //Getter
        public string WorkTitle
        {
            get { return _workName; }
        }

        public int WorkId
        {
            get { return _workId; }
        }

        //Methods
        enum ParseError
        {
            Ok,
            StoryNotFound,
            StoryIsPrivate
        }
        private async Task<ParseError> ParseWorkDetails()
        {
            _logger.Info($"Fetching work data for '{_workId}'");
            
            HttpResponseMessage resp =  await _session.httpClientRedirect.GetAsync($"/works/{_workId}");
            if (resp.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return ParseError.StoryNotFound;
            }
            
            string body = await resp.Content.ReadAsStringAsync();
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml( body );

            var metaGroup = htmlDoc.DocumentNode.SelectSingleNode("//dl[@class='work meta group']");
            if(metaGroup == null)
            {
                return ParseError.StoryIsPrivate;
            }

            var titleNode = htmlDoc.DocumentNode.SelectSingleNode("//h2[@class='title heading'][1]/text()[1]");
            if(titleNode == null)
            {
                throw new Ao3GenericException("Title heading locator found no matches");
            }

            _workName = titleNode.InnerHtml;
            return ParseError.Ok; 

        }

        public static async Task<Ao3Work> GetWorkFromId(Ao3Session session, int workId)
        {
            Ao3Work work = new Ao3Work(session, workId);
            var res = await work.ParseWorkDetails();
            
            if (res == ParseError.StoryNotFound)
            {
                string exceptMsg = $"Couldnt't find work '{workId}' in the archive";
                throw new Ao3NotFoundException(exceptMsg);
            }else if(res == ParseError.StoryIsPrivate)
            {
                string exceptMsg = $"The work '{workId}' is part of a private collection";
                throw new Ao3ForbiddenException(exceptMsg);
            }

            _logger.Info($"Successfully retrieved data for Work {workId}");
            return work;
        }

        public static Ao3Work CreateWork(Ao3Session session, int workId, string workName)
        {
            var work = new Ao3Work(session, workId);
            work._workName = workName;
            return work;
        }

        private Ao3Work(Ao3Session session, int workId)
        {
            _session = session;
            _workId = workId;
        }

        

    }
}
