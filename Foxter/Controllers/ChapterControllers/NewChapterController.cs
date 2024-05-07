using Foxter.AO3;
using Foxter.Controllers.StoryControllers;
using Foxter.Forms;
using Foxter.Models;
using Foxter.Models.Base;
using Foxter.GUI.ChapterViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foxter.Utils;

namespace Foxter.Controllers.ChapterControllers
{
    public class NewChapterController : IChapterController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IChapterModel _model;
        private ScheduleStoryForm _view;
        private Ao3Client _client;
        Dictionary<int, List<BoxItem>> _chapterBuffer;
        bool _initializedUi;

        public async Task<bool> Create(Chapter chapter)
        {
            _logger.Info("creating new chapter, data=" + chapter);
            chapter.AuthorId = _client.GetSession().GetId();
            return await _model.Create(chapter);
        }

        public async Task<bool> Delete(int chapterId)
        {
            return false;
        }

        public async Task RefreshUI()
        {
            try
            {
                _logger.Info("a component requested a user interface refresh");
                if(!_initializedUi)
                {
                    //Assume work box isn't populated
                    var works = await _client.GetAllWorks();
                    var displayItems = works.Select(story => new BoxItem(story.WorkTitle, story.WorkId)).ToList();
                    _view.PopulateWorksBox(displayItems);
                    _initializedUi = true;
                }
                var selectedWork = _view.GetSelectedWorkId();
                if(selectedWork != null)
                {
                    List<BoxItem> displayItems;
                    if (_chapterBuffer.ContainsKey(selectedWork.Value) == false)
                    {
                        _logger.Info($"cache miss: no buffered chapters for story \"{selectedWork.Value}\", fetching from AO3 ");
                        var chapters = await _client.GetChaptersForWork(selectedWork.Value);
                        displayItems = chapters
                            .Where(c => c.Draft)
                            .Select(chapter => new BoxItem(chapter.Title, chapter.Id))
                            .ToList();
                        _chapterBuffer.Add(selectedWork.Value, displayItems);
                        _logger.Info($"buffered {displayItems.Count} chapters.");
                        _logger.Info("newly buffered contents: " + ListToString<BoxItem>.Convert(displayItems));
                    }
                    else
                    {
                        _logger.Info($"{_chapterBuffer.Count} buffered chapters exist for work {selectedWork.Value}.");
                        _logger.Info("buffer contents: " + ListToString<BoxItem>.Convert(_chapterBuffer[selectedWork.Value]));
                        displayItems = _chapterBuffer[selectedWork.Value];
                    }
                    _view.PopulateChaptersBox(displayItems);
                }


            }catch(HttpRequestException ex)
            {
                _logger.Error("http error occured trying to refresh view: " + ex.Message);
                throw ex;
            }

            

        }

        public async Task<bool> Update(int chapterId, Chapter newChapter)
        {
            return false;
        }

        public void ShowForm()
        {
            _logger.Info("brought NewChapterController managed view to foreground");
            _view.ShowDialog();
        }
        

        public NewChapterController(IChapterModel model,ISession session)
        {
            _model = model;
            _client = new Ao3Client(session);
            _view = new ScheduleStoryForm(this);
            _chapterBuffer = new Dictionary<int, List<BoxItem>>();
            _initializedUi = false;
            _logger.Info("created NewChapterController instance");
        }
    }
}
