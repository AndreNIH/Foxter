﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Models.Base
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        List<Chapter> Stories { get; set; }
    }
}