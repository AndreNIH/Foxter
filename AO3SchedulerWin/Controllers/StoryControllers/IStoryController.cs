using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AO3SchedulerWin.Models;

namespace AO3SchedulerWin.Controllers.StoryControllers
{
    public interface IStoryController
    {
        public bool InsertStory(Story story);
        public bool UpdateStory(int id, Story newStory);
        public bool DeleteStory(int id);
        public Story? GetStory(int id);

        public void UpdateViews();

    }
}
