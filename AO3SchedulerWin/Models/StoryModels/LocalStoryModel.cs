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
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
                    command.Parameters.AddWithValue("@notesAtTheStart", false);
                    command.Parameters.AddWithValue("@notesAtTheEnd", false);
                    command.Parameters.AddWithValue("@storyContent", story.Contents);

                    command.Prepare();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch(SQLiteException ex) {
                logger.Error(ex.Message);
            }

            return false;
        }
        public bool UpdateStory(int id, Story newStory)
        {
            throw new NotImplementedException();
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
                var command = new SQLiteCommand("select * from `STORY_UPDATES`", connection);
                List<Story> stories = new List<Story>();
                SQLiteDataReader reader = command.ExecuteReader();

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
                    }catch(InvalidCastException ex)
                    {
                        Console.WriteLine("Could not construct Story object: " + ex.Message);
                    }
                }
                return stories;
            }
        }
        public Story? GetStory(int id)
        {
            throw new NotImplementedException();
        }

    }
}
