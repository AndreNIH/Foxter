using AO3SchedulerWin.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Models
{
    public interface IAuthorModel
    {
        public Task Create(Author authord);
        public Task Update(int authorId, Author newAuthor);
        public Task Delete(int authorId);
        public Task<List<Author>> GetAllAuthors();
        public Task<Author?> GetActiveAuthor();

    }
}
