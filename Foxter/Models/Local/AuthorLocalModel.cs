using Foxter.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Models.Local
{
    public class AuthorLocalModel : IAuthorModel
    {
        private DbProviderFactory _dbProvider;
        private string _connectionString;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(AuthorLocalModel));

        public async Task<bool> Create(Author author)
        {
            await using (var connection = _dbProvider.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                await connection.OpenAsync();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "insert into AUTHORS(AuthorId, Username, Password) values(@id, @username, @password) ";

                //Prepared statement setup
                var idParam = cmd.CreateParameter();
                idParam.ParameterName = "id";
                idParam.Value = author.Id;
                cmd.Parameters.Add(idParam);

                var usernameParam = cmd.CreateParameter();
                usernameParam.ParameterName = "username";
                usernameParam.Value = author.Name;
                cmd.Parameters.Add(usernameParam);

                var passwordParam = cmd.CreateParameter();
                passwordParam.ParameterName = "password";
                passwordParam.Value = author.Password;
                cmd.Parameters.Add(passwordParam);

                //Execute statement
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
                catch (SQLiteException ex)
                {
                    _logger.Error("Create operation failed: " + ex.Message);
                }
                return false;
            }
        }

        public async Task<bool> Delete()
        {
            _logger.Info("Deleting author from model");
            await using (var connection = _dbProvider.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = $"delete from AUTHORS;";
                //Execute statement
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
                catch (SQLiteException ex)
                {
                    _logger.Error("Delete failed: " + ex.Message);
                }
                return false;
            }
        }
        public async Task<Author?> Get()
        {
            await using (var connection = _dbProvider.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                await connection.OpenAsync();

                var cmd = connection.CreateCommand();
                cmd.CommandText = $"select * from AUTHORS;";
                try
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {

                            var author = new Author();
                            author.Id = reader.GetInt32(0);
                            author.Name = reader.GetString(1);
                            author.Password = reader.GetString(2);
                            return author;
                        }
                    }

                }
                catch (SQLiteException ex)
                {
                    _logger.Error(ex.Message);
                }
                return null;
            }
        }

        public AuthorLocalModel(DbProviderFactory provider, string connectionString)
        {
            _dbProvider = provider;
            _connectionString = connectionString;
        }
    }


}
