﻿using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.Forms;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Models.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Views.ChapterViews.TableView
{
    public class ChapterTableView : IChapterView
    {
        //Yes, the view holds a model. It is forwarded to table items
        //which itself forwards it to a ChapterDataForm, where therin
        //a form controller is instaciated
        private IChapterModel _model;
        private ITableUpdateListener _updateListener;
        private TableLayoutPanel _view;
        private Ao3Client _ao3Client;
        
        public ChapterTableView(TableLayoutPanel view, IChapterModel model, ITableUpdateListener updateListener, Ao3Client client)
        {
            _view = view;
            _model = model;
            _ao3Client = client;
            _updateListener = updateListener;
        }

        public void UpdateView(List<Chapter> chapters)
        {
            _view.SuspendLayout();
            foreach (var c in chapters)
            {
                Debug.Assert(_model != null, "a model must be bound to the adapter before upadating the view");
                IChapterTableItemBuilder builder = new ChapterTableItemBuilder();
                var item = builder.SetDatabaseId(c.ChapterId)
                                  .SetAo3Client(_ao3Client)
                                  .SetTableListener(_updateListener)
                                  .SetChapterModel(_model)
                                  .SetStoryTitle(c.StoryTitle)
                                  .SetChapterTitle(c.ChapterTitle)
                                  .SetPublishingDate(c.PublishingDate)
                                  .Build();
                item.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                _view.Controls.Add(item);
            }
            _view.ResumeLayout();
        }

        

    }
}
