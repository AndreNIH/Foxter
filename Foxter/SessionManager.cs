using Foxter.AO3;
using Foxter.Models;
using Foxter.Models.Base;
using Foxter.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter
{
    public class SessionManager
    {

        private ISessionProvider _sessionProvider;
        private IAuthorModel _model;
        private ISession _session;
        private log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()!.DeclaringType);
        

        private async Task<ISession?> RestorePreviousSession(Author author)
        {
            var session = _sessionProvider.GetSession();
            if (await session.Login(author.Name, author.Password) == false)
            {
                return session;
            }
            _logger.Warn("session is no longer valid");
            return null;
        }

        public async Task DeleteSession()
        {
            _session = null;
            var author = await _model.Get();
            if (author != null)
            {
                await _model.Delete();
            }
            _logger.Info("deleted session data");
        }
        
        public bool HasActiveSession()
        {
            if(_session != null && _session.IsAuthenticated())
            {
                return true;
            }
            return false;
        }
        
        public async Task<ISession> CreateSession()
        {
            _logger.Info("creating new session");
            var author = await _model.Get();
            if(author != null)
            {
                var session = await RestorePreviousSession(author);
                if (session != null)
                {
                    await _model.Delete();
                    return session;
                }
            }
            
            return _sessionProvider.GetSession();

        }

        public ISession GetExistingSession()
        {
            return _session;
        }

        public SessionManager(ISessionProvider sessionProvider, IAuthorModel model)
        {
            _sessionProvider = sessionProvider;
            _model = model;
            _session = null;
        }
    }
}
 