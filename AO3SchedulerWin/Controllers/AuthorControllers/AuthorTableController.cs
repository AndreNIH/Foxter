using AO3SchedulerWin.Models.AuthorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Views.AuthorViews;

namespace AO3SchedulerWin.Controllers.AuthorControllers
{
    internal class AuthorTableController : IAuthorController
    {
        public bool RegisterAuthor(Author author)
        {
            return _model.AddAuthor(author);
        }

        public bool UnregisterAuthor(int authorId)
        {
            return _model.RemoveAuthor(authorId);
        }

        public void UpdateViews()
        {
            var authors = _model.GetAllAuthors();
            foreach (var author in authors) _view.QueueViewChange(author);
            _view.ApplyChanges();
        }

        public bool SetActiveAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public int AuthorIdForTablePosition(int tablePosition)
        {
            var allAuthors = _model.GetAllAuthors();
            if (tablePosition > allAuthors.Count) return -1;
            return allAuthors[tablePosition].Id;
        }

        public bool UpdateAuthor(int authorId, Author newAuthorData)
        {
            throw new NotImplementedException();
        }

        public AuthorTableController(IAuthorModel model, IAuthorView view)
        {
            _view = view;
            _model = model;
        }

        private IAuthorView _view;
        private IAuthorModel _model;

    }
}
