using Foxter.Models;
using Foxter.Models.Local;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Providers
{
    public class LocalDbProvider : IDatabaseProvider
    {
        DbProviderFactory _providerFactory;
        string _connStr;
        public IAuthorModel GetAuthorModel()
        {
            return new AuthorLocalModel(_providerFactory, _connStr);
        }

        public IChapterModel GetChapterModel()
        {
            return new ChapterLocalModel(_providerFactory, _connStr);
        }

        public LocalDbProvider(string path)
        {
            _providerFactory = new SQLiteFactory();
            _connStr = $"Data Source={path};Version=3;";
        }
    }
}
