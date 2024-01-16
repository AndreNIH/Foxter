using AO3SchedulerWin.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Models
{
    public class AuthorLocalModel : IAuthorModel
    {
        public Task Create(Author authord)
        {
            throw new NotImplementedException();
        }

        public Task Delete()
        {
            throw new NotImplementedException();
        }

        public Task<Author?> Get()
        {
            throw new NotImplementedException();
        }
    }
}
