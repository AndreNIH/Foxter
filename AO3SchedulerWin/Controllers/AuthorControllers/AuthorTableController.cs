using AO3SchedulerWin.Models.AuthorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Views;

namespace AO3SchedulerWin.Controllers.AuthorControllers
{
    internal class AuthorTableController : IAuthorController
    {
        public bool RegisterAuthor(int authorId, string name, string password)
        {
            Author author = new Author();
            author.Id = authorId;
            author.Name = name;
            author.Password = password;
            _model.AddAuthor(author);
            return true;
        }

        public bool UnregisterAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public void UpdateViews()
        {
            var authors = _model.GetAllAuthors();
            foreach (var author in authors) _view.QueueViewChange(author);
            _view.ApplyChanges();
        }

        public AuthorTableController(IAuthorView view, IAuthorModel model)
        {
            _view = view;
            _model = model;
        }

        private IAuthorView _view;
        private IAuthorModel _model;

    }
}
