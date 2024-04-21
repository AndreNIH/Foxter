using Foxter.GUI.Forms;
using log4net.Repository;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;



namespace Foxter
{
    internal static class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

#if DEBUG
            AllocConsole();
#endif
            string AppId = "Local\\c41fe00c-96c6-4fe5-b536-8db4f45b35a1";
            using (Mutex mtx = new Mutex(false, AppId))
            {
                if (!mtx.WaitOne(0))
                {
                    return;
                }

                //First application instance
                ILoggerRepository repository = log4net.LogManager.GetRepository(Assembly.GetCallingAssembly());
                log4net.Config.XmlConfigurator.Configure(repository, new System.IO.FileInfo("log4net.config"));
                log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Info("running application v" + Assembly.GetExecutingAssembly().GetName().Version.ToString());
                ApplicationConfiguration.Initialize();
                Application.Run(new AppLoaderForm());
            }


            
        }
    }
}