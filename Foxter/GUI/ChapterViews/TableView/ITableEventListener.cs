using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.GUI.ChapterViews.TableView
{
    public interface ITableEventListener
    {
        Task OnEditChapter(int chapterId);
    }
}
