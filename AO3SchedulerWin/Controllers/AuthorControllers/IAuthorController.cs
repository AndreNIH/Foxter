using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Controllers.AuthorControllers
{
    internal interface IAuthorController
    {
        bool RegisterAuthor(int authorId, string user, string password);
        bool UnregisterAuthor(int authorId);
        bool SetActiveAuthor(int authorId);
        void UpdateViews();

        
    }
}
