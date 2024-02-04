using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Views.ChapterViews.TableView
{
    public interface ITableEventListener
    {
        Task OnEditChapter(object sender);
    }
}
