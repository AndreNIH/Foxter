using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.AO3.Exceptions
{
    internal class Ao3NotFoundException : Ao3GenericException
    {
        public Ao3NotFoundException(string message) : base(message)
        {
        }
    }
}
