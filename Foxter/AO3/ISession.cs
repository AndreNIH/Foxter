using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.AO3
{
    public interface ISession
    {
        Task<bool> Login(string username, string password);
        Task<bool> LoadPreviousSession(string data);
        void Reset();

        //Accesors
        int GetId();
        string GetUser();
        bool IsAuthenticated();
        CookieContainer GetCookies();
    }
}
