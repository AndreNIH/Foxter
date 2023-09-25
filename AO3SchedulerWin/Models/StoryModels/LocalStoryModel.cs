using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AO3SchedulerWin.Database;

namespace AO3SchedulerWin.Models.StoryModels
{
    internal class LocalStoryModel : IStoryModel
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool InsertStory(Story story)
        {
            try
            {
                using (var connection = ConnectionFactory.GetConnection())
                {
                    connection.Open();
                    var command = new SQLiteCommand("insert into `STORY_UPDATES` " +
                                                "(authorId, storyId, title, chapterTitle, publishingDate, chapterSummary, chapterNotes, notesAtTheStart, notesAtTheEnd, storyContent) " +
                                                "values (@authorId, @storyId, @title, @chapterTitle, @publishingDate, @chapterSummary, @chapterNotes, @notesAtTheStart, @notesAtTheEnd, @storyContent)",
                                                connection);
                    command.Parameters.AddWithValue("@authorId", story.AuthorId);
                    command.Parameters.AddWithValue("@storyId", story.StoryId);
                    command.Parameters.AddWithValue("@title", story.Title);
                    command.Parameters.AddWithValue("@chapterTitle", story.ChapterTitle);
                    command.Parameters.AddWithValue("@publishingDate", story.PublishingDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@chapterSummary", story.ChapterSummary);
                    command.Parameters.AddWithValue("@chapterNotes", story.ChapterNotes);
                    command.Parameters.AddWithValue("@notesAtTheStart", story.NotesAtStart);
                    command.Parameters.AddWithValue("@notesAtTheEnd", story.NotesAtEnd);
                    command.Parameters.AddWithValue("@storyContent", story.Contents);

                    command.Prepare();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch(SQLiteException ex) {
                _logger.Error(ex.Message);
            }

            return false;
        }
        public bool UpdateStory(int id, Story newStory)
        {
            try
            {
                using (var connection = ConnectionFactory.GetConnection())
                {
                    connection.Open();
                    var command = connection.CreateCommand();
                    command.CommandText = @"update `STORY_UPDATES` set
                                            authorId=@authorId,
                                            storyId=@storyId,
                                            title=@title,
                                            chapterTitle=@chapterTitle,
                                            publishingDate=@publishingDate,
                                            chapterSummary=@chapterSummary,
                                            chapterNotes=@chapterNotes,
                                            notesAtTheStart=@notesAtTheStart,
                                            notesAtTheEnd=@notesAtTheEnd,
                                            storyContent=@storyContent where id=@id";

                    command.Parameters.AddWithValue("@id", newStory.Id);
                    command.Parameters.AddWithValue("@authorId", newStory.AuthorId);
                    command.Parameters.AddWithValue("@storyId", newStory.StoryId);
                    command.Parameters.AddWithValue("@title", newStory.Title);
                    command.Parameters.AddWithValue("@chapterTitle", newStory.ChapterTitle);
                    command.Parameters.AddWithValue("@publishingDate", newStory.PublishingDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.Parameters.AddWithValue("@chapterSummary", newStory.ChapterSummary);
                    command.Parameters.AddWithValue("@chapterNotes", newStory.ChapterNotes);
                    command.Parameters.AddWithValue("@notesAtTheStart", newStory.NotesAtStart);
                    command.Parameters.AddWithValue("@notesAtTheEnd", newStory.NotesAtEnd);
                    command.Parameters.AddWithValue("@storyContent", newStory.Contents);
                    command.Prepare();
                    return command.ExecuteNonQuery() == 1;

                }
            }
            catch (SQLiteException ex)
            {
                _logger.Error(ex.Message);
            }

            return false;
        }
        public bool DeleteStory(int id)
        {
            throw new NotImplementedException();
        }
        public List<Story> GetStories()
        {
            using (var connection = ConnectionFactory.GetConnection())
            {
                connection.Open();
                var command = new SQLiteCommand("select * from `STORY_UPDATES`  order by id desc", connection);
                List<Story> stories = new List<Story>();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        try
                        {
                            var story = new Story();
                            story.Id = reader.GetInt32(0);
                            story.AuthorId = reader.GetInt32(1);
                            story.StoryId = reader.GetInt32(2);
                            story.Title = reader.GetString(3);
                            story.ChapterTitle = reader.GetString(4);
                            story.PublishingDate = reader.GetDateTime(5);
                            story.ChapterSummary = reader.GetString(6);
                            story.ChapterNotes = reader.GetString(7);
                            story.NotesAtStart = reader.GetBoolean(8);
                            story.NotesAtEnd = reader.GetBoolean(9);
                            story.Contents = reader.GetString(10);
                            stories.Add(story);
                        }
                        catch (InvalidCastException ex)
                        {
                            Console.WriteLine("Could not construct Story object: " + ex.Message);
                        }
                    }

                }

                return stories;
            }
        }
        public Story? GetStoryByWorkId(int id)
        {
            using (var connection = ConnectionFactory.GetConnection())
            {
                connection.Open();
                var command = new SQLiteCommand($"select * from `STORY_UPDATES` where storyId={id}", connection);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        try
                        {
                            var story = new Story();
                            story.Id = reader.GetInt32(0);
                            story.AuthorId = reader.GetInt32(1);
                            story.StoryId = reader.GetInt32(2);
                            story.Title = reader.GetString(3);
                            story.ChapterTitle = reader.GetString(4);
                            story.PublishingDate = reader.GetDateTime(5);
                            story.ChapterSummary = reader.GetString(6);
                            story.ChapterNotes = reader.GetString(7);
                            story.NotesAtStart = reader.GetBoolean(8);
                            story.NotesAtEnd = reader.GetBoolean(9);
                            story.Contents = reader.GetString(10);
                            return story;
                        }
                        catch (InvalidCastException ex)
                        {
                            Console.WriteLine("Could not construct Story object: " + ex.Message);
                        }
                    }
                }

            }
            return null;
        }
        public Story? GetStory(int id)
        {
            using (var connection = ConnectionFactory.GetConnection())
            {
                connection.Open();
                var command = new SQLiteCommand($"select * from `STORY_UPDATES` where id={id}", connection);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        try
                        {
                            var story = new Story();
                            story.Id = reader.GetInt32(0);
                            story.AuthorId = reader.GetInt32(1);
                            story.StoryId = reader.GetInt32(2);
                            story.Title = reader.GetString(3);
                            story.ChapterTitle = reader.GetString(4);
                            story.PublishingDate = reader.GetDateTime(5);
                            story.ChapterSummary = reader.GetString(6);
                            story.ChapterNotes = reader.GetString(7);
                            story.NotesAtStart = reader.GetBoolean(8);
                            story.NotesAtEnd = reader.GetBoolean(9);
                            story.Contents = reader.GetString(10);
                            return story;
                        }
                        catch (InvalidCastException ex)
                        {
                            _logger.Error("Could not construct Story object: " + ex.Message);
                        }
                    }
                }

            }
            return null;
        }

    }

 
}
