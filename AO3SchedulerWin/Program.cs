using AO3SchedulerWin.GUI.Forms;
using log4net.Repository;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;




namespace AO3SchedulerWin
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
            ILoggerRepository repository = log4net.LogManager.GetRepository(Assembly.GetCallingAssembly());
            log4net.Config.XmlConfigurator.Configure(repository, new System.IO.FileInfo("log4net.config"));
            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log.Info("running application v" +  System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());

            ApplicationConfiguration.Initialize();
            Application.Run(new AppLoaderForm());
        }
    }
}