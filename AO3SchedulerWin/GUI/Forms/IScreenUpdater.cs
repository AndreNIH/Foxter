using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.GUI.Forms
{
    public interface IScreenUpdater
    {
        Task ChangeScreen(string screenId);
    }
}
