using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Forms;
using AO3SchedulerWin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Views.ChapterViews.TableView
{
    public interface IChapterTableItemBuilder
    {
        //Display Properties
        IChapterTableItemBuilder SetDatabaseId(int id);
        IChapterTableItemBuilder SetStoryTitle(string storyTitle);
        IChapterTableItemBuilder SetChapterTitle(string title);
        IChapterTableItemBuilder SetPublishingDate(DateTime publishingDate);

        //Internal Properties
        IChapterTableItemBuilder SetTableListener(ITableUpdateListener listener);
        IChapterTableItemBuilder SetChapterModel(IChapterModel chapterModel);
        IChapterTableItemBuilder SetAo3Client(Ao3Client client);

        //Builder methods
        void Reset();
        ChapterTableItem Build();
    }
}
