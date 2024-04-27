using Foxter.AO3;
using Foxter.Models;
using Foxter.Models.Base;
using Foxter.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Foxter
{
    public class SessionManager
    {

        private ISessionProvider _sessionProvider;
        private IAuthorModel _model;
        private ISession _session;
        private log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()!.DeclaringType);
        

        public async Task<bool> RestorePreviousSession()
        {
            try
            {
                var author = await _model.Get();
                if (author != null)
                {
                    var session = _sessionProvider.GetSession();
                    if (await session.LoadPreviousSession(author.Sessdata))
                    {
                        _logger.Info("restored existing session");
                        _session = session;
                        return true;
                    }
                }

                _logger.Warn("session is no longer valid");
                //await _model.Delete();
                return false;
            }
            catch (Ao3GenericException ex)
            {
                _logger.Error(ex.Message);
                //await _model.Delete();
                return false;
            }
            
        }

        public async Task<bool> CreateNewSession(string user, string password)
        {
            _logger.Info("creating new session");
            var session =  _sessionProvider.GetSession();
            if(await session.Login(user, password))
            {
                //session.GetCookies().
                var serdat = JsonSerializer.Serialize(session.GetCookies().GetAllCookies());
                
                bool success = await _model.Create(new Author { 
                    Id = session.GetId(), 
                    Name = session.GetUser(), 
                    Sessdata=serdat }
                );
                
                if (success)
                {
                    
                    _logger.Info("successfully created a new session");
                    _session = session;
                    return true;
                }
                else
                {
                    _logger.Warn("login was succesful but a database record couldn't be created");
                    return false;
                }
                
            }
            
            return false;
        }

        public async Task DeleteSession()
        {
            _session.Reset();
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
        
        

        public ISession GetExistingSession()
        {
            return _session;
        }

        public SessionManager(ISessionProvider sessionProvider, IAuthorModel model)
        {
            _sessionProvider = sessionProvider;
            _model = model;
            _session = sessionProvider.GetSession();
        }
    }
}
 