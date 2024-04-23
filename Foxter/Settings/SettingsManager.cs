using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Settings
{
    //TODO: Find a better way of doing this
    //I don't like using a singleton for this
    public class SettingsManager
    {

        private static readonly Lazy<SettingsManager> lazy = new Lazy<SettingsManager>(() => new SettingsManager());
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()!.DeclaringType);
        private string _configPath;
        public static SettingsManager Get { get { return lazy.Value; } }
        public AppConfiguration Configuration { get; set; }
        
        public bool Persist()
        {
            try
            {
                using (var fs = new StreamWriter(_configPath))
                {
                    string serialized = JsonConvert.SerializeObject(Configuration);
                    fs.Write(serialized);
                    _logger.Info($"persisted application settings: {serialized}");
                    return true;

                }
            }catch(IOException ex)
            {
                _logger.Error("file IO error: " + ex.Message);
            }
            
            return false;
        }

        public bool Load()
        {
            try
            {
                _logger.Info($"loading application configuration from {_configPath}");
                using (var fs = new StreamReader(_configPath))
                {
                    string data = fs.ReadToEnd();
                    var conf = JsonConvert.DeserializeObject<AppConfiguration>(data);
                    if (conf != null)
                    {
                        _logger.Info($"loaded application configuration: {data}");
                        Configuration = conf;
                        return true;
                    }
                    else
                    {
                        _logger.Warn("application configuration deserialization failed");
                    }
                }
                
            }
            catch (FileNotFoundException)
            {
                _logger.Info("application configuration file not foud");
                return false;
            }catch(IOException ex)
            {
                _logger.Error("file IO error: " + ex.Message);
            }
            
            return false;
        }

        private SettingsManager() {

            Configuration = new AppConfiguration();
            Configuration.runAtStartup = true;
            Configuration.startMinimized = true;
            Configuration.publishMode = AppConfiguration.PublishMode.KLocal;
            _configPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "AO3S", "appsettings.json");
        }

    }

    public class AppConfiguration
    {
        public enum PublishMode
        {
            kRemote,
            KLocal
        }


        public bool runAtStartup { get; set; }
        public bool startMinimized { get; set; }
        public bool sendToTray { get; set; }
        public PublishMode publishMode { get; set; }

        
    }
}
