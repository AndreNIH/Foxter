using Foxter.AO3;
using Foxter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Publisher
{
    public class LocalPublishingStrategy : IPublisherStrategy
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IAuthorModel _authorModel;
        private IChapterModel _chapterModel;
        private Ao3Client _client;

        public LocalPublishingStrategy(IAuthorModel authorModel, IChapterModel chapterModel, Ao3Session session)
        {
            _authorModel = authorModel;
            _chapterModel = chapterModel;
            _client = new Ao3Client(session);
        }

        public async Task<PublishResult> Publish()
        {
            PublishResult result = new();
            result.success = 0;
            result.failed = 0;
            var author = await _authorModel.Get();
            if(author == null) return result;

            var chapters = await _chapterModel.GetAllChaptersFromAuthor(author.Id);
            var uploads = chapters.Where(c => c.PublishingDate <= DateTime.Now).ToList();
            foreach( var c in uploads )
            {
                try
                {
                    bool success = await _client.PostDraft(c.StoryId, c.ChapterId);
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
                    _logger.Error("failed to publish chapter batch. " + e.Message);
                    result.failed += uploads.Count -  uploads.IndexOf(c) + 1 ;
                    break;
                }
            }

            return result;
        }
    }
}
