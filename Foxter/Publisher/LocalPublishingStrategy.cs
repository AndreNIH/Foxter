using Foxter.AO3;
using Foxter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Foxter.Publisher
{
    public class LocalPublishingStrategy : IPublisherStrategy
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IChapterModel _chapterModel;
        
        private Ao3Client _client;

        public LocalPublishingStrategy(IChapterModel chapterModel, ISession session)
        {
            _chapterModel = chapterModel;
            _client = new Ao3Client(session);
        }

        public async Task<PublishResult> Publish()
        {
            PublishResult result = new();
            result.success = 0;
            result.failed = 0;
            var chapters = await _chapterModel.GetAllChaptersFromAuthor(_client.GetSession().GetId());
            var uploads = chapters.Where(c => c.PublishingDate <= DateTime.Now).ToList();
            foreach( var c in uploads )
            {
                try
                {
                    bool success = true;//await _client.PostDraft(c.StoryId, c.ChapterId);
                    if(success)
                    {
                        result.success++;
                        _logger.Info($"published \"{c.ChapterTitle}\" (id:{c.ChapterId})");
                        await _chapterModel.Delete(c.ChapterId);
                    }
                    else
                    {
                        _logger.Warn($"failed to publish \"{c.ChapterTitle}\" (id:{c.ChapterId})");
                        result.failed++;
                    }

                }catch (HttpRequestException e)
                {
                    //If an HTTPRequestException occured we will assume all subsequent call in
                    //this batch will fail
                    _logger.Error("http error, failed to publish chapter batch. " + e.Message);
                    result.failed += uploads.Count -  uploads.IndexOf(c) + 1 ;
                    break;
                }
            }

            return result;
        }
    }
}
