using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.Forms;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Models.Base;
using AO3SchedulerWin.Views.ChapterViews;
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
        List<BaseChapterFormView.BoxItem> _workBuffer;
        Dictionary<int, List<BaseChapterFormView.BoxItem>> _chapterBuffer;

        public async Task<bool> Create(Chapter chapter)
        {
            chapter.AuthorId = _client.GetSession().Id;
            return await _model.Create(chapter);
        }

        public async Task<bool> Delete(int chapterId)
        {
            return false;
        }

        public async Task InitUI()
        {
            try
            {
                _logger.Info("Retrieving user works from the server");
                var works = await _client.GetAllWorks();
                var displayItems = works.Select(story => new BoxItem(story.WorkTitle, story.WorkId)).ToList();
                _view.PopulateWorksBox(displayItems);
            }catch(HttpRequestException ex)
            {
                _logger.Error(ex.Message);
                throw ex;
            }
            
        }

        public async Task RefreshUI()
        {

            try
            {
                _logger.Info("Refreshing user interface");
                var selectedStory = _view.GetSelectedStoryId();
                if (selectedStory == null) return;
                List<BoxItem> displayItems;
                if (_chapterBuffer.ContainsKey(selectedStory.Value) == false)
                {
                    _logger.Info($"Retrieving chapter data for {selectedStory.Value} from the server");
                    var chapters = await _client.GetChaptersForWork(selectedStory.Value);
                    displayItems = chapters
                        .Where(c => c.Draft)
                        .Select(chapter => new BoxItem(chapter.Title, chapter.Id))
                        .ToList();
                    _logger.Info($"Buffered {displayItems.Count} chapters for work {selectedStory.Value}");
                    _chapterBuffer.Add(selectedStory.Value, displayItems);
                }
                else
                {
                    _logger.Info($"Retrieving chapter data for {selectedStory.Value} from the local buffer");
                    displayItems = _chapterBuffer[selectedStory.Value];
                }
                _view.PopulateChaptersBox(displayItems);
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

        

        public NewChapterController(
            IChapterModel model,
            Ao3Client client,
            Form managedForm,
            Button ao3Button,
            ComboBox storyBox,
            ComboBox chapterBox,
            DateTimePicker uploadPicker,
            Button okButton,
            Button deleteButton
            )
        {
            _model = model;
            _client = client;
            _view = new ScheduleStoryForm();
            _workBuffer = new List<BaseChapterFormView.BoxItem>();
            _chapterBuffer = new Dictionary<int, List<BaseChapterFormView.BoxItem>>();
        }
    }
}
