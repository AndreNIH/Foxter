using AO3SchedulerWin.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Models.Components
{
    internal class ChapterLocalModel : IChapterModel
    {
        public Task Create(Chapter chapter)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int chapterId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Chapter>> GetAllChaptersFromAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<Chapter> GetChapterById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int chapterId, Chapter newChapter)
        {
            throw new NotImplementedException();
        }
    }
}
