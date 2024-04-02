using Foxter.AO3;
using Foxter.Models;
using Foxter.Models.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Factories
{
    internal class LocalAppServiceFactory : IAppServiceFactory
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(LocalAppServiceFactory));
        private DbProviderFactory _dbProvider;
        private string _connectionStr;
        private string _dbDirectory;
        private string _dbFile;

        void EnsureDatabaseIsCreated()
        {
            if (!Directory.Exists(_dbDirectory))
            {
                _logger.Info($"The specified route doesnt exist. Creating subdirectories: {_dbDirectory}");
                Directory.CreateDirectory(_dbDirectory);
                _logger.Info("Subdirectories created");
            }

            _logger.Info("Creating database file");
            SQLiteConnection.CreateFile(Path.Combine(_dbDirectory, _dbFile));
            using (var conn = new SQLiteConnection($"Data Source={_dbFile};Version=3;"))
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(Resources.AppStrings.DbCreationScript, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            _logger.Info($"Created application database in {_dbFile}");
        }

        private bool IsDatabaseCreated()
        {
            string path = _dbFile;
            if (File.Exists(path))
            {
                _logger.Info($"Database found in '${path}'. Skipping file creation");
                return true;
            }
            else
            {
                _logger.Info($"Database was not found in '${path}'. Attempting to create file");
                return false;
            }
        }



        IAuthorModel IAppServiceFactory.CreateAuthorModel()
        {
            _logger.Info("Created AuthorLocalModel instance");
            return new AuthorLocalModel(_dbProvider, _connectionStr);
        }

        public IChapterModel CreateChapterModel()
        {
            _logger.Info("Instanciating local Chapter model");
            return new ChapterLocalModel(_dbProvider, _connectionStr);
        }

        

        public LocalAppServiceFactory(string dbPath)
        {
            //It's pointless to use dependency injection here
            //just instantiate the db factory in the constructor
            _dbProvider = new SQLiteFactory();
            _dbDirectory = dbPath;
            _dbFile = Path.Combine(dbPath, "las.sqlite"); //Local Application Storage
            _connectionStr = $"Data Source={_dbFile};Version=3;";
            if(!IsDatabaseCreated()) EnsureDatabaseIsCreated();
        }
    }
}
