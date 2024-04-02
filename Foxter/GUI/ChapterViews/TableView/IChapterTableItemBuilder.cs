using Foxter.AO3;
using Foxter.Forms;
using Foxter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.GUI.ChapterViews.TableView
{
    public interface IChapterTableItemBuilder
    {
        //Display Properties
        IChapterTableItemBuilder SetDatabaseId(int id);
        IChapterTableItemBuilder SetStoryTitle(string storyTitle);
        IChapterTableItemBuilder SetChapterTitle(string title);
        IChapterTableItemBuilder SetPublishingDate(DateTime publishingDate);

        //Internal Properties
        IChapterTableItemBuilder SetTableEventListener(ITableEventListener listener);

        //Builder methods
        void Reset();
        ChapterTableItem Build();
    }
}
