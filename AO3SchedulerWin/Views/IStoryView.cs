using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AO3SchedulerWin.Models;

namespace AO3SchedulerWin.Views
{
    internal interface IStoryView
    {
        void UpdateView(List<Story> stories);
    }
}
