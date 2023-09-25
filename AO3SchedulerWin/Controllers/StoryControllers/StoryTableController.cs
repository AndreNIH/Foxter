using AO3SchedulerWin.Models;
using AO3SchedulerWin.Models.StoryModels;
using AO3SchedulerWin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Controllers.StoryControllers
{
    internal class StoryTableController : IStoryController
    {
        public StoryTableController(IStoryView view, IStoryModel model)
        {
            _view = view;
            _model = model;
        }

        public bool DeleteStory(int id)
        {
            return _model.DeleteStory(id);
        }

        public Story? GetStory(int id)
        {
            return _model.GetStoryByWorkId(id);
        }

        public bool InsertStory(Story story)
        {
            return _model.InsertStory(story);
        }

        public bool UpdateStory(int id, Story newStory)
        {
            return _model.UpdateStory(id, newStory);
        }

        public void UpdateViews()
        {
            _view.UpdateView(_model.GetStories());
        }

        private IStoryView _view;
        private IStoryModel _model;
    }
}
