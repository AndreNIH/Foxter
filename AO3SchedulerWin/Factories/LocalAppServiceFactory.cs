using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Models.AuthorModels;
using AO3SchedulerWin.Models.StoryModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Factories
{
    internal class LocalAppServiceFactory : IAppServiceFactory
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(LocalAppServiceFactory));
        private static Ao3Session _session = new Ao3Session();
        private AppConfiguration _appConfiguration;
        public IAuthorModel CreateAuthorModel()
        {
            _logger.Info("Instanciating local Author model. ");
            return new AuthorLocalModel();
        }

        public IStoryModel CreateStoryModel()
        {

            _logger.Info("Instanciating loca Story model. ");
            return new LocalStoryModel();
        }

        public Ao3Session GetSession()
        {
            return _session;   
        }

        //This constructor probably wont see much use
        //Local models don't require any configuration
        public LocalAppServiceFactory(FileStream configFileStream)
        {
            _logger.Info("Configuring AppServiceFactory with file " + configFileStream.Name);
            using (var sr = new StreamReader(configFileStream))
            {
                _appConfiguration = JsonConvert.DeserializeObject<AppConfiguration>(sr.ReadToEnd());
            }
        }

        public LocalAppServiceFactory()
        {
            _logger.Info("Configuring LocalAppServiceFactory with default settings");
            _appConfiguration = new AppConfiguration();
            _appConfiguration.ServiceType = ServiceType.kLocal;
            _appConfiguration.RemoteServerAdress = "";
            _appConfiguration.RemoteUsername = "";
            _appConfiguration.RemoteServerAdress = "";
        }
    }
}
