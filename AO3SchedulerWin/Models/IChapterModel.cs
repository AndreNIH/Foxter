using AO3SchedulerWin.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Models
{
    public interface IChapterModel
    {
        public Task<bool> Create(Chapter chapter);
        public Task<bool> Update(int chapterId, Chapter newChapter);
        public Task<bool> Delete(int chapterId);
        public Task<Chapter?> GetChapterById(int id);
        public Task<List<Chapter>> GetAllChaptersFromAuthor(int authorId);
        public Task<int?> GetChapterCountFromAuthor(int authorId);

        public void RegisterObserver(IChapterModelUpdateListener observer);
        public void UnregisterObserver(IChapterModelUpdateListener observer);
    }

    public interface IChapterModelUpdateListener
    {
        public Task OnChapterModelUpdated();
    }
}
