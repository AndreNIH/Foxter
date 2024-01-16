using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Models;
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
        IChapterModel CreateChapterModel();
        
    }
}
