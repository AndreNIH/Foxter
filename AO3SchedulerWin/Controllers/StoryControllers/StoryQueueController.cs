using AO3SchedulerWin.Models;
using AO3SchedulerWin.Models.StoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Controllers.StoryControllers
{
    internal class StoryQueueController : IStoryController
    {
        private IStoryModel _storyModel;
        private Label _queuedStoriesLabel;
        public bool DeleteStory(int id)
        {
            throw new NotImplementedException();
        }

        public Story? GetStory(int id)
        {
            throw new NotImplementedException();
        }

        public bool InsertStory(Story story)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStory(int id, Story newStory)
        {
            throw new NotImplementedException();
        }

        public void UpdateViews()
        {
            var story = _storyModel.GetStories();
            int queuedStories = story.Count(s => s.PublishingDate >  DateTime.Now);
            if (queuedStories == 0) _queuedStoriesLabel.Text = "Nothing to upload";
            else if (queuedStories == 1) _queuedStoriesLabel.Text = "You have: 1 pending story upload";
            else _queuedStoriesLabel.Text = $"You have: {queuedStories} pending story uploads";
        }

        public StoryQueueController(IStoryModel storyModel, Label label)
        {
            _storyModel = storyModel;
            _queuedStoriesLabel = label;
        }
    }
}
