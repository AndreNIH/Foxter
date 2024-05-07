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

namespace Foxter.Controllers.ChapterControllers
{
    public class UpdateChapterController : IChapterController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IChapterModel _model;
        Ao3Client _client;
        int _workId;
        int _chapterId;
        ScheduleStoryForm _view;
        bool _initializedUi = false;

        public async Task<bool> Create(Chapter chapter)
        {
            return false;
        }

        public async Task<bool> Delete(int chapterId)
        {
            return await _model.Delete(chapterId);
        }

        public async Task<bool> Update(int chapterId, Chapter newChapter)
        {
            _logger.Info($"updating \"{chapterId}\", data=" + newChapter);
            newChapter.AuthorId = _client.GetSession().GetId();
            return await  _model.Update(chapterId, newChapter);
        }

        public async Task RefreshUI()
        {
            try
            {
                _logger.Info("a component requested a user interface refresh");
                if (_initializedUi)
                {
                    _logger.Info("supress ui update flag is set, refresh aborted");
                    return;
                }
                var work = await _client.GetWork(_workId);
                var workDisplay = new List<BoxItem>() { new(work.WorkTitle, work.WorkId) };
                var chapters = await _client.GetChaptersForWork(_workId);
                var chapter = chapters.First(c => c.Id == _chapterId);
                _logger.Info("fetched story and chapter from AO3 servers");
                _view.PopulateWorksBox(new List<BoxItem>() { new(work.WorkTitle, work.WorkId) });
                _view.PopulateChaptersBox(new List<BoxItem>() { new(chapter.Title, chapter.Id) });
                _initializedUi = true;

            }
            catch (HttpRequestException ex)
            {
                _logger.Error("http exception: " + ex.Message);
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    MessageBox.Show(
                        "The selected chapter not found in Archive of Our Own. It may have been deleted.\n" +
                        "It will now be deleted from the upload queue",
                        "Chapter not found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                        );
                    await _model.Delete(_chapterId);
                    _view.Close();

                }
                else
                {
                    MessageBox.Show(
                       "A network error occured: " + ex.Message,
                       "Network error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error
                       );
                }

                _logger.Info("Falling back on local model data to populate views");
                //TODO: this works fine for the time being, but remote models
                //are introduced this needs to be wrapped by a try-catch block
                var storedChapter = await _model.GetChapterById(_chapterId); 
                if(storedChapter != null)
                {
                    _view.PopulateWorksBox(new List<BoxItem>() { new(storedChapter.StoryTitle, storedChapter.StoryId) });
                    _view.PopulateChaptersBox(new List<BoxItem>() { new(storedChapter.ChapterTitle, storedChapter.ChapterId) });
                }
                
            }
        }

        public void ShowForm()
        {
            _view.ShowDialog();
        }
      

        public UpdateChapterController(
            IChapterModel model,
            ISession session,
            int workId,
            int chapterId)
        {
            _model = model;
            _client = new Ao3Client(session);
            _workId = workId;
            _chapterId = chapterId;
            _view = new ScheduleStoryForm(this, chapterId);
        }
    }
}
