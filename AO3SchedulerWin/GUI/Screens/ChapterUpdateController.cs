using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.GUI.Screens
{
    internal class ChapterUpdateController : IChapterController
    {
        public Task<bool> Create(Chapter chapter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int chapterId)
        {
            throw new NotImplementedException();
        }

        public Task InitUI()
        {
            throw new NotImplementedException();
        }

        public Task RefreshUI()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int chapterId, Chapter newChapter)
        {
            throw new NotImplementedException();
        }
    }
}
