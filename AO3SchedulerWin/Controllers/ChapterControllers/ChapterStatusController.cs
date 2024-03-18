using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Models.Base;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Controllers.ChapterControllers
{
    public class ChapterStatusController : IChapterController
    {
        private IChapterModel _model;
        private Label _pendingLabel;
        private Label _failedLabel;
        private int _authorId;


        public Task<bool> Create(Chapter chapter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int chapterId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int chapterId, Chapter newChapter)
        {
            throw new NotImplementedException();
        }


        public async Task RefreshUI()
        {
            var chapters = await _model.GetAllChaptersFromAuthor(_authorId);
            int pendingUploads = chapters.Count();
            int failedUploads = chapters.Count(chapter => chapter.PublishingDate < DateTime.Now);

            if (pendingUploads == 1) _pendingLabel.Text = "You have 1 pending chapter upload";
            else _pendingLabel.Text = $"You have {pendingUploads} pending chapter uploads";

            if (failedUploads > 0)
            {
                if (failedUploads == 1) _failedLabel.Text = "One chapter could not be uploaded";
                else _failedLabel.Text = $"{failedUploads} chapters could not be uploaded";
                _failedLabel.Visible = true;
            }
            else
            {
                _failedLabel.Visible = false;
            }
        }

        public ChapterStatusController(IChapterModel model, Label pendingLabel, Label failedLabel, int authorId)
        {
            _model = model;
            _pendingLabel = pendingLabel;
            _failedLabel = failedLabel;
            _authorId = authorId;
        }
    }
}
