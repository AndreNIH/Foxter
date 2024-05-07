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
using System.Data.SQLite;
using Foxter.Utils;
using System.Diagnostics.Eventing.Reader;


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

#if DEBUG
            XmlConfigurator.Configure(repository, new System.IO.FileInfo("log4net.debug.config"));
#else
            XmlConfigurator.Configure(repository, new System.IO.FileInfo("log4net.config"));
#endif
        }


        private static void LoadApplicationSettings()
        {
            //Initialize settings
            if (!SettingsManager.Get.Load())
            {
                SettingsManager.Get.Persist();
            }
        }

        private static bool CreatePhysicalDatabaseStructure()
        {
            string root = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Foxter");
            string dbFile = Path.Combine(root, "las.sqlite");
            try
            {
                if (File.Exists(dbFile))
                {
                    _logger.Info($"database found in '${dbFile}'. Skipping file creation");
                    return true;
                }
                _logger.Info($"database was not found in '${dbFile}'. Creating file");
                if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                    _logger.Info("subdirectories created");
                }
                
                SQLiteConnection.CreateFile(dbFile);
                var conn = new SQLiteConnection($"Data Source={dbFile};Version=3;");
                conn.Open();
                using (var cmd = new SQLiteCommand(Resources.AppStrings.DbCreationScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Dispose();
                _logger.Info("database file created");
                return true;
            }
            catch (SQLiteException ex)
            {
                _logger.Error("SQLiteExcepion on database creation: " + ex.Message);
                File.Delete(dbFile);
                return false;
            }
        }

        private static IDatabaseProvider GetDatabaseProvider()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData),"Foxter","las.sqlite");
            if (SettingsManager.Get.Configuration.publishMode == AppConfiguration.PublishMode.KLocal)
            {
                return new LocalDbProvider(path);
            }

            return null;
        }

        static void StartApplication(bool startupLaunch)
        {
            IDatabaseProvider dbProvider = GetDatabaseProvider();
            SessionManager sessionMgr = new SessionManager(new SessionProvider(), dbProvider.GetAuthorModel());
            
            ApplicationContext appCtx;
            _logger.Info("startup launch: " + startupLaunch);
            if (startupLaunch && SettingsManager.Get.Configuration.startMinimized)
            {
                Form form = new AppLoaderForm(dbProvider, sessionMgr, true);
                _logger.Info("launching application in hidden mode");
                appCtx = new HiddenApplicationContext(form);
            }
            else
            {
                Form form = new AppLoaderForm(dbProvider, sessionMgr);
                _logger.Info("launching application in regular mode");
                appCtx = new ApplicationContext(form);
            }

            Application.Run(appCtx);

        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
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
                
                //Configuration
                ConfigureLogger();
                ApplicationConfiguration.Initialize();
                
                //Application launch
                _logger.Info("running application v" + Assembly.GetExecutingAssembly().GetName().Version!.ToString());
                bool startupLaunch = Array.Exists(args, arg => arg == "--startup");
                if (!CreatePhysicalDatabaseStructure()) return;
                LoadApplicationSettings();
                StartApplication(startupLaunch);
            }


            
        }
    }
}