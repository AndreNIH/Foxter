using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AO3SchedulerWin.Database
{
    internal class ConnectionFactory
    {
        private static readonly string _databaseFile = "database.sqlite";
        private static bool _dbInitialized = false;
        private static log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(ConnectionFactory));

        private static string GetDabasePath()
        {
            string localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string path = Path.Combine(localAppDataPath, "AO3S", "database/");
            return path;
        }

        private static SQLiteConnection GetConnectionNoInit()
        {
            return new SQLiteConnection($"Data Source={GetDabasePath() + _databaseFile};Version=3;");
        }

        private static void CreateTables()
        {
            using (var conn = GetConnectionNoInit())
            {
                conn.Open();
                SQLiteCommand command = new SQLiteCommand(Resources.AppStrings.DbCreationScript, conn);
                command.ExecuteNonQuery();
            }
        }


        private static void CreatePhysicalDatabase()
        {
            Directory.CreateDirectory(GetDabasePath());
            if (!File.Exists(GetDabasePath() + _databaseFile))
            {
                _logger.Info("Creating physical database file");
                SQLiteConnection.CreateFile(GetDabasePath() + _databaseFile);
            }
        }

        public static SQLiteConnection GetConnection()
        {
            if (_dbInitialized == false)
            {

                CreatePhysicalDatabase();
                CreateTables(); //Maybe check if the db is valid before attempting running the script?
                _dbInitialized = true;
                _logger.Info("Succesfully initialized database");
            }
            return GetConnectionNoInit();
        }
    }
}
