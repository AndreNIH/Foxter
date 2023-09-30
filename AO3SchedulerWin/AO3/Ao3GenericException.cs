using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.AO3
{
    internal class Ao3GenericException : Exception
    {
        public Ao3GenericException(string? message) : base(message)
        {
        }
    }
}
