using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Controllers.ChapterControllers
{
    public class ChapterController : IChapterController
    {
        private IChapterModel _model;
        public async Task<bool> Create(Chapter chapter)
        {
            return await _model.Create(chapter);
        }

        public async Task<bool> Delete(int chapterId)
        {
            return await _model.Delete(chapterId);
        }

        public async Task<List<Chapter>> GetAllChaptersFromAuthor(int authorId)
        {
            return await _model.GetAllChaptersFromAuthor(authorId);
        }

        public async Task<Chapter?> GetChapterById(int id)
        {
            return await _model.GetChapterById(id);
        }

        public async Task<bool> Update(int chapterId, Chapter newChapter)
        {
            return await _model.Update(chapterId, newChapter);
        }

        public void UpdateViews(){}

        public ChapterController(IChapterModel model)
        {
            _model = model;
        }
    }
}
