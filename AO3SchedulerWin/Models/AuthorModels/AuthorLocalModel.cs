using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AO3SchedulerWin.Database;

namespace AO3SchedulerWin.Models.AuthorModels
{
    internal class AuthorLocalModel : IAuthorModel
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool AddAuthor(Author author)
        {
            try
            {
                using (var connection = ConnectionFactory.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"insert into `AUTHORS` (id, username, password) 
                                            values (@id, @username, @password)";
                    command.Parameters.AddWithValue("@id", author.Id);
                    command.Parameters.AddWithValue("@username", author.Name);
                    command.Parameters.AddWithValue("@password", author.Password);
                    command.Prepare();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch(SQLiteException ex)
            {
                logger.Error(ex.Message);
            }
            
            return false;
        }

        public Author? GetActiveAuthor()
        {
            try
            {
                using (var connection = ConnectionFactory.GetConnection())
                {
                    connection.Open();
                    var command = new SQLiteCommand("select id from `AUTHORS` where active=1", connection);
                    using (var rd = command.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            int activeAuthorId = rd.GetInt32(0);
                            return GetAuthorById(activeAuthorId);
                        }

                    }

                }
            }catch(SQLiteException ex)
            {
                logger.Error(ex.Message);
            }
            
            return null;
        }

        public List<Author> GetAllAuthors()
        {
            try
            {
                using(var connection = ConnectionFactory.GetConnection())
                {
                    connection.Open();
                    var command = new SQLiteCommand("select * from `AUTHORS`", connection);
                    using (var rd = command.ExecuteReader())
                    {
                        List<Author> authors = new List<Author>();
                        while (rd.Read())
                        {
                            Author author = new Author();
                            author.Id = rd.GetInt32(0);
                            author.Name = rd.GetString(1);
                            author.Password = rd.GetString(2);
                            authors.Add(author);
                        }
                        return authors;
                    }
                    
                }
                
            }catch(SQLiteException ex)
            {
                Console.WriteLine(ex.Message);
                logger.Error(ex.Message);
            }
            return null;
        }

        public Author? GetAuthorById(int id)
        {
            try
            {
                using (var connection =  ConnectionFactory.GetConnection())
                {
                    connection.Open();
                    var command = new SQLiteCommand($"select * from `AUTHORS` where id={id}", connection);
                    using (var rd = command.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            Author author = new Author();
                            author.Id = rd.GetInt32(0);
                            author.Name = rd.GetString(1);
                            author.Password = rd.GetString(2);
                            return author;
                        }
                    }
                        
                }
            }catch(SQLiteException ex)
            {
                logger.Error(ex.Message);
            }
            return null;
        }

        public bool RemoveAuthor(int authorId)
        {
            try
            {
                using (var connection = ConnectionFactory.GetConnection())
                {
                    connection.Open();
                    var command = new SQLiteCommand($"delete from `AUTHORS` where id={authorId}", connection);
                    return command.ExecuteNonQuery() >= 1;
                }

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                logger.Error(ex.Message);
            }
            return false;
        }

        public bool SetActiveUser(int id)
        {
            try
            {
                using(var connection = ConnectionFactory.GetConnection())
                {
                    connection.Open();
                    var setActiveCommand = new SQLiteCommand($"update `AUTHORS` set active=1 where id={id}", connection);
                    var resetCommand = new SQLiteCommand($"update `AUTHORS` set active=0 where id!={id}", connection);
                    int rowsAffected = setActiveCommand.ExecuteNonQuery();
                    if (rowsAffected < 1) return false;
                    resetCommand.ExecuteNonQuery();
                    return true;

                }
            }catch(SQLiteException ex)
            {
                MessageBox.Show(ex.Message);
                logger.Error(ex.Message);
            }
            return false; 
        }

        public bool UpdateAuthor(int id, Author author)
        {
            throw new NotImplementedException();
        }
    }
}
