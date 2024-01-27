using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Controllers.StoryControllers;
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
    public class UpdateChapterController : IChapterController
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        IChapterModel _model;
        UpdateChapterFormView _view;
        Ao3Client _client;
        int _workId;
        int _chapterId;
        public Task<bool> Create(Chapter chapter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int chapterId)
        {
            throw new NotImplementedException();
        }

        public async Task InitUI()
        {

            try
            {
                var work = await _client.GetWork(_workId);
                var workDisplay = new List<BaseChapterFormView.BoxItem>(){ new(work.WorkTitle, work.WorkId)};

                var chapters = await _client.GetChaptersForWork(_workId);
                var target = chapters.Select(c => c.Id == _chapterId).ToList();
            }catch(HttpRequestException ex)
            {
                _logger.Warn("InitUI http exception: " + ex.Message);
                if(ex.StatusCode == System.Net.HttpStatusCode.NotFound)
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
                       "A network rror occured: " + ex.Message,
                       "Network error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error
                       );
                }

                _logger.Info("Falling back on local model data to populate views");
                var chapter = await _model.GetChapterById(_chapterId); //This shouldn't throw
                _view.PopulateStoriesBox(new List<BaseChapterFormView.BoxItem>() { 
                    new(chapter.StoryTitle, chapter.StoryId) 
                });
                _view.PopulateChaptersBox(new List<BaseChapterFormView.BoxItem>() { 
                    new(chapter.ChapterTitle, chapter.ChapterId) 
                });
            }
            
            //_view.PopulateStoriesBox();
            //_view.PopulateChaptersBox();
        }

        public async Task RefreshUI()
        {
        }

        public Task<bool> Update(int chapterId, Chapter newChapter)
        {
            throw new NotImplementedException();
        }

        public UpdateChapterController(
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
            _view = new UpdateChapterFormView(this, 
                0,
                managedForm,
                ao3Button,
                storyBox,
                chapterBox,
                uploadPicker,
                okButton,
                deleteButton);


        }
    }
}
