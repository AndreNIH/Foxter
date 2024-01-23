using AO3SchedulerWin.Database;
using AO3SchedulerWin.Models.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Models.Local
{
    public class ChapterLocalModel : IChapterModel
    {
        private DbProviderFactory _dbProvider;
        private string _connectionString;
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(ChapterLocalModel));

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
                    await cmd.PrepareAsync();
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

        public async Task<bool> Delete(int chapterId)
        {
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
                cmd.CommandText = $"select * from CHAPTERS where WrittenBy={authorId}";
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
                try
                {
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if(await reader.ReadAsync())
                        {
                            return new Chapter()
                            {
                                ChapterId = reader.GetInt32(0),
                                StoryId = reader.GetInt32(1),
                                StoryTitle = reader.GetString(2),
                                ChapterTitle = reader.GetString(3),
                                PublishingDate = reader.GetDateTime(4),
                                AuthorId = reader.GetInt32(5)
                            };
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
            var chapter = new Chapter();
            await using (var connection = _dbProvider.CreateConnection())
            {
                connection.ConnectionString = _connectionString;
                await connection.OpenAsync();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"update CHAPTERS set values 
                                    ChapterId=@id, 
                                    StoryId=@storyId,
                                    StoryTitle=@storyTitle, 
                                    ChapterTitle=@chapterTitle, 
                                    PublishingDate=@publishingDate, 
                                    WrittenBy=@author 
                                    WHERE ChapterId=@id ";

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
                    await cmd.PrepareAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
                catch (SQLiteException ex)
                {
                    _logger.Error("Create operation failed: " + ex.Message);
                }
            }
                return false;
        }

        public ChapterLocalModel(DbProviderFactory dbProvider, string connectionString)
        {
            _dbProvider = dbProvider;
            _connectionString = connectionString;
        }
    }
}
