using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Models.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Factories
{
    internal class LocalAppServiceFactory : IAppServiceFactory
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(LocalAppServiceFactory));
        private DbProviderFactory _dbProvider;
        private string _connectionStr;
        private string _dbPath;

        void EnsureDatabaseIsCreated()
        {
            string path = _dbPath;
            if (File.Exists(path))
            {
                _logger.Info($"Database found in '${path}'. Skipping file creation");
                return;
            }
            SQLiteConnection.CreateFile(path);
            using (var conn = new SQLiteConnection($"Data Source={path};Version=3;"))
            {
                conn.Open();
                var cmd = new SQLiteCommand(Resources.AppStrings.DbCreationScript, conn);
                cmd.ExecuteNonQuery();
            }

            _logger.Info($"Created application database in {path}");
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

        

        public LocalAppServiceFactory()
        {
            _dbProvider = new SQLiteFactory();
            _dbPath = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData), 
                "AO3S", 
                "appstorage.sqlite"
                );
            _connectionStr = $"Data Source={_dbPath};Version=3;";
            EnsureDatabaseIsCreated();
        }
    }
}
