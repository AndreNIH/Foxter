using Foxter.Models;
using Foxter.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Controllers.AuthorControllers
{
    public class LoginAuthorController : IAuthorController
    {
        private IAuthorModel _model;
        public async Task<bool> RegisterAuthor(Author author)
        {
            return await _model.Create(author);
        }

        public async Task<bool> UnregisterAuthor()
        {
            return await _model.Delete();
        }

        Task IAuthorController.UpdateViews()
        {
            return Task.CompletedTask;
        }

        public LoginAuthorController(IAuthorModel model)
        {
            _model = model;
        }

    }
}
