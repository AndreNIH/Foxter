using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AO3SchedulerWin.Models.StoryModels
{
    public interface IStoryModel
    {
        public bool InsertStory(Story story);
        public bool UpdateStory(int id, Story newStory);
        public bool DeleteStory(int id);
        public List<Story> GetStories();
        public Story? GetStory(int id);
    }
}
