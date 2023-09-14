using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AO3SchedulerWin.Utils
{
    public class  AppConfiguration
    {
        public int ActiveUser { get; set; }
    }
    
    public class LocalConfig
    {
        
        //Singleton
        private static readonly Lazy<LocalConfig> instance = new Lazy<LocalConfig>(() => new LocalConfig());
        public static LocalConfig Manager 
        { 
            get { return instance.Value; } 
        }

        //Configuration fields
        private AppConfiguration configuration;

        //Serder methods
        public bool SaveConfig()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("config.json"))
                {
                    string json = JsonConvert.SerializeObject(this);
                    sw.Write(json);
                    return true;
                }
            }catch(Exception ex) 
            {
                return false; 
            }
        }

        public bool LoadConfig()
        {
            try
            {

            }catch(Exception ex)
            {

            }
        }
        
        
        //Constructor
        private LocalConfig() 
        {

        }

    }
}
