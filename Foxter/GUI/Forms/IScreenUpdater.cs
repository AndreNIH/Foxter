using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.GUI.Forms
{
    public interface IScreenUpdater
    {
        void ChangeScreen(ScreenId screenId);
    }
    public enum ScreenId
    {
        MAIN,
        SCHEDULE,
        LOGIN,
        LOGGED_IN,
        NO_USER,
        SETTINGS,
        BACKUP_LOGIN
    }

}
