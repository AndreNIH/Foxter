using AO3SchedulerWin.Models.AuthorModels;
using AO3SchedulerWin.Views.AuthorViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Controllers.AuthorControllers
{
    internal class LoggedAuthorController : IAuthorController
    {
        public bool RegisterAuthor(int authorId, string user, string password)
        {
            throw new NotImplementedException();
        }

        public bool SetActiveAuthor(int authorId)
        {
            return _model.SetActiveUser(authorId);
                
        }

        public bool UnregisterAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public void UpdateViews()
        {
            var author = _model.GetActiveAuthor();
            _view.QueueViewChange(author);
            _view.ApplyChanges();
        }

        public LoggedAuthorController(IAuthorModel model, IAuthorView view)
        {
            _model = model;
            _view = view;
        }

        private IAuthorModel _model;
        private IAuthorView _view;
    }
}
