using Foxter.AO3;
using Foxter.Models;
using Foxter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Factories
{
    public interface IAppServiceFactory
    {
        IAuthorModel CreateAuthorModel();
        IChapterModel CreateChapterModel();
        
    }
}
