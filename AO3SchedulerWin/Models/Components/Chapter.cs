using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Models.Base
{
    public class Chapter
    {
        public int ChapterId { get; set; }
        public int StoryId { get; set; }
        public string StoryTitle { get; set; }
        public string ChapterTitle { get; set; }
        public DateTime PublishingDate { get; set; }
        public string ChapterSummary { get; set; }
        public string ChapterNotes { get; set; }
        public bool NotesAtStart { get; set; }
        public bool NotesAtEnd { get; set; }
        public string Contents { get; set; }

        public Chapter()
        {
            //Initialize all member string values to empty strings
            StoryTitle = string.Empty; 
            ChapterTitle = string.Empty;
            ChapterSummary = string.Empty;
            ChapterNotes = string.Empty;
            Contents = string.Empty;
            NotesAtStart = false; NotesAtEnd = false;


        }

    }
}
