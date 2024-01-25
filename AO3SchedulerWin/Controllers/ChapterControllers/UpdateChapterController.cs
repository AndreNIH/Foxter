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
            var chapters = await _client.GetChaptersForWork(_workId);
            var target = chapters.Select(c => c.Id == _chapterId).ToList();
            if (target.Count() == 0) { 
            
            
            }

            _view.PopulateChaptersBox();
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
