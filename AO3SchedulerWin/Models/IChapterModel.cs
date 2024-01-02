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
        public Task Create(Chapter chapter);
        public Task Update(int chapterId, Chapter newChapter);
        public Task Delete(int chapterId);
        public Task<Chapter> GetChapterById(int id);
        public Task<List<Chapter>> GetAllChaptersFromAuthor(int authorId);
    }
}
