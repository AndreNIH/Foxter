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
        public bool InsertStory(Chapter story);
        public bool UpdateStory(int id, Chapter newStory);
        public bool DeleteStory(int id);
        public Chapter? GetStory(int id);

        public void UpdateViews();

    }
}
