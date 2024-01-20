using AO3SchedulerWin.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Controllers.AuthorControllers
{
    public interface IAuthorController
    {
        Task<bool> RegisterAuthor(Author author);
        Task<bool> UnregisterAuthor();
        Task UpdateViews();

        
    }
}
