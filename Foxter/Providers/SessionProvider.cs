using Foxter.AO3;
using Foxter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Providers
{
    public class SessionProvider : ISessionProvider
    {
        public ISession GetSession()
        {
            return new Ao3Session();
        }

        
    }
}
