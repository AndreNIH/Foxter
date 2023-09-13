using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Utils
{
    internal class Ao3HttpClient
    {
        private static readonly Lazy<Ao3HttpClient> lazy = new Lazy<Ao3HttpClient>(() => new Ao3HttpClient());
        private CookieContainer cookieContainer;
        
        
        
        public static Ao3HttpClient Instance { 
            get
            {
                return lazy.Value;
            }
        }

        public HttpClient Client { get; }

        public void ClearAllCookies()
        {
            cookieContainer.GetAllCookies().Clear();
        }

        private Ao3HttpClient() 
        {

            cookieContainer = new CookieContainer();


            HttpClientHandler handler = new HttpClientHandler()
            {
                AllowAutoRedirect = false,
                CookieContainer = cookieContainer
            };
            Client = new HttpClient()
            {
                BaseAddress = new Uri("https://archiveofourown.org/"),
            };
        }
    }
}
