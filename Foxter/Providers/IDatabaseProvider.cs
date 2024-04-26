using Foxter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Providers
{
    public interface IDatabaseProvider
    {
        IAuthorModel GetAuthorModel();
        IChapterModel GetChapterModel();
    }
}
