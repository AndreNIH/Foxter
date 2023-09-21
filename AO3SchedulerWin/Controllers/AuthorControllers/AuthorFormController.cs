using AO3SchedulerWin.Models;
using AO3SchedulerWin.Models.AuthorModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Controllers.AuthorControllers
{
    internal class AuthorFormController : IAuthorController
    {
        private static log4net.ILog _loggeer = log4net.LogManager.GetLogger(typeof(AuthorFormController));
        private IAuthorModel _model;
        private TextBox _usernameTextbox;
        private TextBox _passwordTextbox;
        private int? _authorId = null;

        public bool RegisterAuthor(Author author)
        {
            return _model.AddAuthor(author);
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
            if(_authorId != null)
            {
                Author? author = _model.GetAuthorById(_authorId.Value);
                if (author != null) _usernameTextbox.Text = author.Name;
                else _loggeer.Warn($"AuthorId '{_authorId}' was not found in Author model");
            }
        }

        public bool UpdateAuthor(int authorId, Author newAuthorData)
        {
            if(authorId == newAuthorData.Id)
            {
                return _model.UpdateAuthor(authorId, newAuthorData);
            }
            _loggeer.Warn($"Mismatched author Ids. {authorId} is not {newAuthorData.Id}");
            return false; 
        }

        public AuthorFormController(IAuthorModel model, TextBox usernameTextbox, TextBox passwordTextbox, int? authorToLoad=null)
        {
            _model = model;
            _usernameTextbox = usernameTextbox;
            _passwordTextbox  = passwordTextbox;
            _authorId = authorToLoad;
        }
    }
}
