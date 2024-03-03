using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.Forms;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Models.Base;
using AO3SchedulerWin.GUI.ChapterViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Controllers.ChapterControllers
{
    public class NewChapterController : IChapterController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IChapterModel _model;
        private ScheduleStoryForm _view;
        private Ao3Client _client;
        List<BoxItem> _workBuffer;
        Dictionary<int, List<BoxItem>> _chapterBuffer;
        bool _initializedUi;

        public async Task<bool> Create(Chapter chapter)
        {
            chapter.AuthorId = _client.GetSession().Id;
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
                _logger.Info("refreshing user interface");
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
                        _logger.Info($"Retrieving chapter data for {selectedWork.Value} from the server");
                        var chapters = await _client.GetChaptersForWork(selectedWork.Value);
                        displayItems = chapters
                            .Where(c => c.Draft)
                            .Select(chapter => new BoxItem(chapter.Title, chapter.Id))
                            .ToList();
                        _logger.Info($"Buffered {displayItems.Count} chapters for work {selectedWork.Value}");
                        _chapterBuffer.Add(selectedWork.Value, displayItems);
                    }
                    else
                    {
                        _logger.Info($"Retrieving chapter data for {selectedWork.Value} from the local buffer");
                        displayItems = _chapterBuffer[selectedWork.Value];
                    }
                    _view.PopulateChaptersBox(displayItems);
                }


            }catch(HttpRequestException ex)
            {
                _logger.Error(ex.Message);
                throw ex;
            }

            

        }

        public async Task<bool> Update(int chapterId, Chapter newChapter)
        {
            return false;
        }

        public void ShowForm()
        {
            _view.ShowDialog();
        }
        

        public NewChapterController(IChapterModel model,Ao3Session session)
        {
            _model = model;
            _client = new Ao3Client(session);
            _view = new ScheduleStoryForm(this);
            _workBuffer = new List<BoxItem>();
            _chapterBuffer = new Dictionary<int, List<BoxItem>>();
            _initializedUi = false;
        }
    }
}
