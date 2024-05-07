using Foxter.Models.Base;
using Foxter.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Models.Local
{
    public class ChapterLocalModel : IChapterModel
    {
        private DbProviderFactory _dbProvider;
        private string _connectionString;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(ChapterLocalModel));
        private List<IChapterModelUpdateListener> _updateListeners = new List<IChapterModelUpdateListener>();
        public async Task<bool> Create(Chapter chapter)
        {
            await using (var connection = _dbProvider.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                await connection.OpenAsync();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "insert into CHAPTERS values(@id, @storyId, @storyTitle, @chapterTitle, @publishingDate, @author)";

                var idParam = cmd.CreateParameter();
                idParam.ParameterName = "id";
                idParam.Value = chapter.ChapterId;
                cmd.Parameters.Add(idParam);

                var storyId = cmd.CreateParameter();
                storyId.ParameterName = "storyId";
                storyId.Value = chapter.StoryId;
                cmd.Parameters.Add(storyId);

                var storyTitleParam = cmd.CreateParameter();
                storyTitleParam.ParameterName = "storyTitle";
                storyTitleParam.Value = chapter.StoryTitle;
                cmd.Parameters.Add(storyTitleParam);

                var chapterTitleParam = cmd.CreateParameter();
                chapterTitleParam.ParameterName = "chapterTitle";
                chapterTitleParam.Value = chapter.ChapterTitle;
                cmd.Parameters.Add(chapterTitleParam);

                var publishingDateParam = cmd.CreateParameter();
                publishingDateParam.ParameterName = "publishingDate";
                publishingDateParam.Value = chapter.PublishingDate.ToString("yyyy-MM-dd HH:mm:ss");
                cmd.Parameters.Add(publishingDateParam);

                var authorParam = cmd.CreateParameter();
                authorParam.ParameterName = "author";
                authorParam.Value = chapter.AuthorId;
                cmd.Parameters.Add(authorParam);

                //Execute statement
                try
                {
                    _logger.Debug("inserting Chapter object in local database: " + chapter.ToString());
                    await cmd.PrepareAsync();
                    await cmd.ExecuteNonQueryAsync();
                    _updateListeners.ForEach(listener => listener.OnChapterModelUpdated());
                    return true;
                }
                catch (SQLiteException ex)
                {
                    _logger.Error("Create operation failed: " + ex.Message);
                }
                return false;
            }
        }

        public async Task<bool> Delete(int chapterId)
        {
            _logger.Debug($"deleting chapter(id:{chapterId}) from local database");
            await using (var connection = _dbProvider.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                await connection.OpenAsync();
                var cmd = connection.CreateCommand();
                cmd.CommandText = $"delete from CHAPTERS where ChapterId={chapterId};";
                //Execute statement
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                    _updateListeners.ForEach(listener => listener.OnChapterModelUpdated());
                    return true;
                }
                catch (SQLiteException ex)
                {
                    _logger.Error("Delete failed: " + ex.Message);
                }
                return false;
            }
        }

        public async Task<List<Chapter>> GetAllChaptersFromAuthor(int authorId)
        {
            List<Chapter> chapters = new List<Chapter>();
            await using(var connection = _dbProvider.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                await connection.OpenAsync();
                var cmd = connection.CreateCommand();
                cmd.CommandText = $"select * from CHAPTERS where WrittenBy={authorId} order by publishingDate asc";
                try
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            chapters.Add(new Chapter()
                            {
                                ChapterId = reader.GetInt32(0),
                                StoryId = reader.GetInt32(1),
                                StoryTitle = reader.GetString(2),
                                ChapterTitle = reader.GetString(3),
                                PublishingDate = reader.GetDateTime(4),
                                AuthorId = reader.GetInt32(5)
                            });
                        }
                    }
                }catch(SQLiteException ex)
                {
                    _logger.Error("GetAllChaptersFromAuthor failed: " + ex.Message);
                }
            }
            return chapters;
        }

        public async Task<Chapter?> GetChapterById(int id)
        {
            await using (var connection = _dbProvider.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                await connection.OpenAsync();
                var cmd = connection.CreateCommand();
                cmd.CommandText = $"select * from CHAPTERS where ChapterId={id}";
                try
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if(await reader.ReadAsync())
                        {
                            var c = new Chapter()
                            {
                                ChapterId = reader.GetInt32(0),
                                StoryId = reader.GetInt32(1),
                                StoryTitle = reader.GetString(2),
                                ChapterTitle = reader.GetString(3),
                                PublishingDate = reader.GetDateTime(4),
                                AuthorId = reader.GetInt32(5)
                            };

                            return c;
                        }
                        return null;
                    }
                }
                catch(SQLiteException ex)
                {
                    _logger.Warn(ex.Message);
                    return null;
                }
            }
        }

        public async Task<bool> Update(int chapterId, Chapter newChapter)
        {
            await using (var connection = _dbProvider.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                await connection.OpenAsync();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"update CHAPTERS set  
                                    ChapterId=@id, 
                                    StoryId=@storyId,
                                    StoryTitle=@storyTitle, 
                                    ChapterTitle=@chapterTitle, 
                                    PublishingDate=@publishingDate, 
                                    WrittenBy=@author 
                                    WHERE ChapterId=@id ";

                var idParam = cmd.CreateParameter();
                idParam.ParameterName = "id";
                idParam.Value = chapterId;
                cmd.Parameters.Add(idParam);

                var storyId = cmd.CreateParameter();
                storyId.ParameterName = "storyId";
                storyId.Value = newChapter.StoryId;
                cmd.Parameters.Add(storyId);

                var storyTitleParam = cmd.CreateParameter();
                storyTitleParam.ParameterName = "storyTitle";
                storyTitleParam.Value = newChapter.StoryTitle;
                cmd.Parameters.Add(storyTitleParam);

                var chapterTitleParam = cmd.CreateParameter();
                chapterTitleParam.ParameterName = "chapterTitle";
                chapterTitleParam.Value = newChapter.ChapterTitle;
                cmd.Parameters.Add(chapterTitleParam);

                var publishingDateParam = cmd.CreateParameter();
                publishingDateParam.ParameterName = "publishingDate";
                publishingDateParam.Value = newChapter.PublishingDate.ToString("yyyy-MM-dd HH:mm:ss");
                cmd.Parameters.Add(publishingDateParam);

                var authorParam = cmd.CreateParameter();
                authorParam.ParameterName = "author";
                authorParam.Value = newChapter.AuthorId;
                cmd.Parameters.Add(authorParam);

                //Execute statement
                try
                {
                    _logger.Debug($"update chapter(id: {chapterId}) data in local database, new chapter data" + newChapter.ToString());
                    await cmd.PrepareAsync();
                    await cmd.ExecuteNonQueryAsync();
                    _updateListeners.ForEach(listener => listener.OnChapterModelUpdated());
                    return true;
                }
                catch (SQLiteException ex)
                {
                    _logger.Error("Create operation failed: " + ex.Message);
                }
            }
                return false;
        }

        public async Task<int?> GetChapterCountFromAuthor(int authorId)
        {
            await using (var connection = _dbProvider.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                await connection.OpenAsync();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "select count(*) from CHAPTERS";
                try
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return reader.GetInt32(0);
                        }
                        return 0; //this line shouldn't execute, but just to be safe
                    }
                }
                catch (SQLiteException ex)
                {
                    _logger.Error(ex.Message);
                    return null;
                }
            }
        }

        public void RegisterObserver(IChapterModelUpdateListener observer)
        {
            _logger.Info($"Registered ChapterLocalModel observer object {observer}");
            _updateListeners.Add(observer);
        }

        public void UnregisterObserver(IChapterModelUpdateListener observer)
        {
            _logger.Info($"Unregistered ChapterLocalModel observer object {observer}");
            _updateListeners.Remove(observer);
        }

      

        public ChapterLocalModel(DbProviderFactory dbProvider, string connectionString)
        {
            _dbProvider = dbProvider;
            _connectionString = connectionString;
        }
    }
}
