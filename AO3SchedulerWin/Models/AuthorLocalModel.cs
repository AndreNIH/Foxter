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

        public Task Delete(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<Author?> GetActiveAuthor()
        {
            throw new NotImplementedException();
        }

        public Task<List<Author>> GetAllAuthors()
        {
            throw new NotImplementedException();
        }

        public Task Update(int authorId, Author newAuthor)
        {
            throw new NotImplementedException();
        }
    }
}
