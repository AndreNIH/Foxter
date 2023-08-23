using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Models.AuthorModels
{
    internal interface IAuthorModel
    {
        bool AddAuthor(Author author);
        bool UpdateAuthor(int id, Author author);
        bool RemoveAuthor(Author author);
        List<Author> GetAllAuthors();
        Author? GetActiveAuthor();
     
    }
}
