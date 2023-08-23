using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Models.StoryModels
{
    internal class TestStoryModel : IStoryModel
    {
        public bool InsertStory(Story story)
        {
            _storyList.Add(story);
            return true;
        }
        public bool UpdateStory(int id, Story newStory)
        {
            int storyIndex = _storyList.FindIndex(e => e.StoryId == id);
            _storyList[storyIndex] = newStory;
            return true;
        }
        public bool DeleteStory(int id)
        {
            int storyIndex = _storyList.FindIndex(e => e.StoryId == id);
            _storyList.RemoveAt(storyIndex);
            return true;
        }
        public List<Story> GetStories()
        {
            return _storyList;
        }
        public Story? GetStory(int id)
        {
            return _storyList.Find(e => e.StoryId == id);
        }

        public TestStoryModel()
        {
            var s1 = new Story();
            s1.Title = "Preloaded Test Data";
            s1.ChapterTitle = "Lorem Ipsum";
            s1.StoryId = 1;
            s1.AuthorId = 2;
            s1.Contents = "Hello";
            _storyList.Add(s1);
        }

        private List<Story> _storyList = new List<Story>();
    }
}
