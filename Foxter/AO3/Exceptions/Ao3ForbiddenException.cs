﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.AO3.Exceptions
{
    internal class Ao3ForbiddenException : Ao3GenericException
    {
        public Ao3ForbiddenException(string message) : base(message)
        {
        }
    }
}
