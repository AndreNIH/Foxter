using Foxter.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Controllers.AuthorControllers
{
    public interface IAuthorController
    {
        Task<bool> RegisterAuthor(Author author);
        Task<bool> UnregisterAuthor();
        Task UpdateViews();

        
    }
}
