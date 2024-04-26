using Foxter.GUI.Forms;
using Foxter.Settings;
using log4net.Repository;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using log4net;
using Foxter.Providers;
using log4net.Config;


namespace Foxter
{
    internal static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        
        private static ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod()!.DeclaringType);
        private static void ConfigureLogger()
        {
            ILoggerRepository repository = LogManager.GetRepository(Assembly.GetCallingAssembly());
            XmlConfigurator.Configure(repository, new System.IO.FileInfo("log4net.config"));
        }


        private static void LoadApplicationSettings()
        {
            //Initialize settings
            if (!SettingsManager.Get.Load())
            {
                SettingsManager.Get.Persist();
            }
        }

        private static IDatabaseProvider GetDatabaseProvider()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),"AO3S","las.sqlite");
            if (SettingsManager.Get.Configuration.publishMode == AppConfiguration.PublishMode.KLocal)
            {
                return new LocalDbProvider(path);
            }

            return null;
        }

        static async Task StartApplication(bool startupLaunch)
        {
            LoadApplicationSettings();
            IDatabaseProvider dbProvider = GetDatabaseProvider();
            SessionManager sessionMgr = new SessionManager(new SessionProvider(), dbProvider.GetAuthorModel());
            await sessionMgr.RestorePreviousSession();
            Application.Run(new MainForm(dbProvider, sessionMgr));
            /*if (startupLaunch && SettingsManager.Get.Configuration.startMinimized)
            {
                
                new MainForm(dbProvider, sessionMgr);
            }*/

        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

#if DEBUG
            AllocConsole();
#endif
            string AppId = "Local\\c41fe00c-96c6-4fe5-b536-8db4f45b35a1";
            using (Mutex mtx = new Mutex(false, AppId))
            {
                //Single instance check
                if (!mtx.WaitOne(0)) return; 
                
                ConfigureLogger();
                ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod()!.DeclaringType);
                log.Info("running application v" + Assembly.GetExecutingAssembly().GetName().Version!.ToString());
                ApplicationConfiguration.Initialize();
                await StartApplication(true);
            }


            
        }
    }
}