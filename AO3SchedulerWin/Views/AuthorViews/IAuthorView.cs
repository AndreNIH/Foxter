using AO3SchedulerWin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Views.AuthorViews
{
    internal interface IAuthorView
    {
        public void QueueViewChange(Author author);
        public void ApplyChanges();

    }
}
