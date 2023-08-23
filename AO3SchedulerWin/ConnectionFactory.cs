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

namespace AO3SchedulerWin
{
    internal class ConnectionFactory
    {
        private static readonly string _databaseFile = "database.sqlite";
        private static bool _dbInitialized = false;

        private static String GetDabasePath()
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
                SQLiteConnection.CreateFile(GetDabasePath() + _databaseFile);
            }
        }

        public static SQLiteConnection GetConnection()
        {
            try
            {
                if(_dbInitialized == false)
                {
                    CreatePhysicalDatabase();
                    CreateTables(); //Maybe check if the db is valid before attempting running the script?
                    _dbInitialized = true;
                }
                return GetConnectionNoInit();
            }catch(Exception ex)
            {
                //TODO: Log something
                throw ex;
            }
            
        }
    }
}
