using Foxter.AO3;
using Foxter.Controllers.ChapterControllers;
using Foxter.Controllers.StoryControllers;
using Foxter.Forms;
using Foxter.Models;
using Foxter.Models.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.GUI.ChapterViews.TableView
{
    public class ChapterTableView : IChapterModelUpdateListener, ITableEventListener
    {
        private IChapterModel _model;
        private TableLayoutPanel _tableView;
        private ISession _session;
        private TabControl _tabView;

        public void DisplayActive(bool value)
        {
            _tabView.SelectedIndex = value ? 1 : 0;
        }

        public async Task OnChapterModelUpdated()
        {
            var allChapters = await _model.GetAllChaptersFromAuthor(_session.GetId());
            _tableView.SuspendLayout();
            _tableView.Controls.Clear();
            foreach (var c in allChapters)
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
            DisplayActive(_tableView.Controls.Count > 0);
            _tableView.ResumeLayout();

        }

        public async Task OnEditChapter(int chapterId)
        {
            var chapter = await _model.GetChapterById(chapterId);
            if (chapter == null)
            {
                return;
            }

            int workid = chapter.StoryId;
            int chapterid = chapter.ChapterId;
            var formController = new UpdateChapterController(_model, _session, workid, chapterid);
            formController.ShowForm();
        }

        public ChapterTableView(IChapterModel model, TableLayoutPanel tableView, TabControl tabView, ISession session)
        {
            _model = model;
            _tableView = tableView;
            _tabView = tabView;
            _session = session;
            _model.RegisterObserver(this);
        }


        ~ChapterTableView()
        {
            _model.UnregisterObserver(this);
        }
    }
}
