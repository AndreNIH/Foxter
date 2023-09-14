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
                    var command = new SQLiteCommand("insert into `AUTHORS` (id, username, password) " +
                                                    "values (@id, @username, @password)",
                                                    connection);
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
                    SQLiteCommand loggedUserQuery = new SQLiteCommand("select loggedUserId from `LOCAL_SETTINGS`", connection);
                    SQLiteDataReader loggedUserRd = loggedUserQuery.ExecuteReader();
                    if(loggedUserRd.Read())
                    {
                        int activeAuthorId = loggedUserRd.GetInt32(0);
                        SQLiteCommand authorQuerry = new SQLiteCommand($"select * from `AUTHORS` where id={activeAuthorId}", connection);
                        SQLiteDataReader authorRd = authorQuerry.ExecuteReader();
                        if (authorRd.Read())
                        {
                            Author author = new Author();
                            author.Id = authorRd.GetInt32(0);
                            author.Name = authorRd.GetString(1);
                            author.Password = authorRd.GetString(2);
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

        public List<Author> GetAllAuthors()
        {
            try
            {
                using(var connection = ConnectionFactory.GetConnection())
                {
                    connection.Open();
                    var command = new SQLiteCommand("select * from `AUTHORS`", connection);
                    SQLiteDataReader reader = command.ExecuteReader();
                    List<Author> authors = new List<Author>();
                    while (reader.Read())
                    {
                        Author author = new Author();
                        author.Id = reader.GetInt32(0);
                        author.Name = reader.GetString(1);
                        author.Password = reader.GetString(2);
                        authors.Add(author);
                    }
                    return authors;
                }
                
            }catch(SQLiteException ex)
            {
                logger.Error(ex.Message);
            }
            return null;
        }

        public Author? GetAuthorById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAuthor(int authorId)
        {
            try
            {
                using (var connection = ConnectionFactory.GetConnection())
                {
                    connection.Open();
                    var command = new SQLiteCommand($"delete from `AUTHORS` where id={authorId}", connection);
                    command.ExecuteNonQuery();
                    
                    return true;
                }

            }
            catch (SQLiteException ex)
            {
                logger.Error(ex.Message);
            }
            return false;
        }

        public bool SetActiveUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAuthor(int id, Author author)
        {
            throw new NotImplementedException();
        }
    }
}
