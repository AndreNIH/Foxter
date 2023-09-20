using log4net.Repository;
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
            try
            {
                ILoggerRepository repository = log4net.LogManager.GetRepository(Assembly.GetCallingAssembly());
                log4net.Config.XmlConfigurator.Configure(repository, new System.IO.FileInfo("log4net.config"));

                AllocConsole();
                ApplicationConfiguration.Initialize();
                Application.Run(new MainForm());

            }
            catch(Exception ex)
            {
                MessageBox.Show("Something went wrong. The application will close\n\r " +
                                "Details:\n\r" + ex.Message,
                                "Fatal Error", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);
            }
            
            
        }
    }
}