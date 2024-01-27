using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AO3SchedulerWin.Models.Base;

namespace AO3SchedulerWin.Controllers.StoryControllers
{
    public interface IChapterController
    {
        public Task<bool> Create(Chapter chapter);
        public Task<bool> Update(int chapterId, Chapter newChapter);
        public Task<bool> Delete(int chapterId);
        
        public Task RefreshUI();
        public Task InitUI();
    }
}
