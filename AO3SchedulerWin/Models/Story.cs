using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Models
{
    internal class Story
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int StoryId { get; set; }
        public string Title { get; set; }
        public string ChapterTitle { get; set; }
        public DateTime PublishingDate { get; set; }
        public string ChapterSummary { get; set; }
        public string ChapterNotes { get; set; }
        public bool NotesAtStart { get; set; }
        public bool NotesAtEnd { get; set; }
        public string Contents { get; set; }

    }
}
