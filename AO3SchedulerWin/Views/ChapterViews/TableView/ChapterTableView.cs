using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Controllers.ChapterControllers;
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
    public class ChapterTableView : IChapterModelUpdateListener, ITableEventListener
    {
        private IChapterModel _model;
        private ChapterTableController _controller;
        private TableLayoutPanel _tableView;
        private Ao3Session _session;
        private TabControl _tabView;

        public void DisplayActive(bool value)
        {
            _tabView.SelectedIndex = value ? 1 : 0;
        }

        public async Task OnChapterModelUpdated()
        {
            var allChapters = await _model.GetAllChaptersFromAuthor(_session.Id);
            _tableView.SuspendLayout();
            _tableView.Controls.Clear();
            foreach(var c in allChapters)
            {
                IChapterTableItemBuilder builder = new ChapterTableItemBuilder();
                //TODO: Add a mediator reference to the builder class
                var item = builder.SetDatabaseId(c.ChapterId)
                                  .SetStoryTitle(c.StoryTitle)
                                  .SetChapterTitle(c.ChapterTitle)
                                  .SetPublishingDate(c.PublishingDate)
                                  .SetTableEventListener(this)
                                  .Build();
                item.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                _tableView.Controls.Add(item);
            }
            _tableView.ResumeLayout();
        }

        public void OnEditChapter(object sender)
        {
            foreach(var item in _tableView.Controls)
            {
                var chapterTableItem = (ChapterTableItem)item;
                Debug.Assert(chapterTableItem != null);
                Console.WriteLine(chapterTableItem.GetId());
            }
        }

        public ChapterTableView(ChapterTableController controller, IChapterModel model, TableLayoutPanel tableView, TabControl tabView, Ao3Session session)
        {
            _model = model;
            //_controller = controller;
            _tableView = tableView;
            _tabView = tabView;
            _session = session;
            _model.RegisterObserver(this);
        }







        //Yes, the view holds a model. It is forwarded to table items
        //which itself forwards it to a ChapterDataForm, where therin
        //a form controller is instaciated
        /*private IChapterModel _model;
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

        
        */
    }
}
