using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Factories
{
    enum ServiceType
    {
        kLocal,
        kRemote
    }
    internal class AppConfiguration
    {
        public ServiceType ServiceType { get; set; }
        public string? RemoteServerAdress { get;set; }
        public string? RemoteUsername { get;set; }
        public string? RemotePassword { get;set; }
    }
}
