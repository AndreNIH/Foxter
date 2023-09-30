using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Models.AuthorModels;
using AO3SchedulerWin.Models.StoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Factories
{
    public interface IAppServiceFactory
    {
        IAuthorModel CreateAuthorModel();
        IStoryModel CreateStoryModel();
        
        //TODO: Make this an interface
        Ao3Session GetSession();
    }
}
