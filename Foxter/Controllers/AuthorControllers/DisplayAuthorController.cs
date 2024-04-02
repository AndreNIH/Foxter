using Foxter.Models;
using Foxter.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Controllers.AuthorControllers
{
    public class DisplayAuthorController : IAuthorController
    {
        IAuthorModel _model;
        Label _view;

        public async Task<bool> RegisterAuthor(Author author)
        {
            return false;
        }

        public async Task<bool> UnregisterAuthor()
        {
            return false;
        }

        public async Task UpdateViews()
        {
            var author = await _model.Get();
            if(author != null)
            {
                _view.Text = author.Name;
            }
        }

        public DisplayAuthorController(IAuthorModel model, Label view)
        {
            _model = model;
            _view = view;
        }
    }
}
