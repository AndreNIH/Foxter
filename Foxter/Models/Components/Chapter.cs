using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Models.Base
{
    public class Chapter
    {
        public int ChapterId { get; set; }
        public int StoryId { get; set; }
        public DateTime PublishingDate { get; set; }
        public int AuthorId { get; set; } 
        
        //We keep these properties to avoid having to
        //act as a cache, and avoid unecessary,
        //time consuming requests to AO3
        public string StoryTitle { get; set; } 
        public string ChapterTitle { get; set; }


        public override string ToString()
        {
            return $"ChapterId: {ChapterId}, " +
                   $"StoryId: {StoryId}, " +
                   $"PublishingDate: {PublishingDate.ToShortDateString()}, " +
                   $"AuthorId: {AuthorId}, " +
                   $"StoryTitle: {StoryTitle}, " +
                   $"ChapterTitle: {ChapterTitle}";
        }




    }
}
