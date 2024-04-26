using Foxter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Providers
{
    public class LocalDbProvider : IDatabaseProvider
    {
        public IAuthorModel GetAuthorModel()
        {
            throw new NotImplementedException();
        }

        public IChapterModel GetChapterModel()
        {
            throw new NotImplementedException();
        }
    }
}
