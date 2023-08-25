using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Models.AuthorModels
{
    internal class AuthorTestModel : IAuthorModel
    {
        public bool AddAuthor(Author author)
        {
            _authors.Add(author);
            return true;
        }

        public List<Author> GetAllAuthors()
        {
            return _authors;
        }

        public Author? GetAuthorById(int id)
        {
            return _authors.Find(e => e.Id == id);
        }

        public bool RemoveAuthor(Author author)
        {
            throw new NotImplementedException();   
        }

        public bool UpdateAuthor(int id, Author author)
        {
            throw new NotImplementedException();
        }

        public Author? GetActiveAuthor()
        {
            return _authors.Find(a => a.Id == _activeAuthorId);
        }

        public bool SetActiveUser(int id)
        {
            _activeAuthorId = id;
            return true;
        }

        private List<Author> _authors = new List<Author>();
        private int _activeAuthorId=-1;
        
    }
}
