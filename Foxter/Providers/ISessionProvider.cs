using Foxter.AO3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Providers
{
    public interface ISessionProvider
    {
        ISession GetSession();
    }
}
