using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AO3SchedulerWin.Models.Base;

namespace AO3SchedulerWin.GUI.ChapterViews
{
    internal interface IChapterView
    {
        void UpdateView(List<Chapter> chapters);
    }
}
