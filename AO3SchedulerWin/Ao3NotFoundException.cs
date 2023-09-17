using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin
{
    internal class Ao3NotFoundException : Ao3GenericException
    {
        public Ao3NotFoundException(string message) : base(message)
        {
        }
    }
}
