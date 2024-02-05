using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Models.Base;
using AO3SchedulerWin.Views.ChapterViews.TableView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Controllers.ChapterControllers
{
    public class ChapterTableController : IChapterController
    {
        private Ao3Session _session;
        private ChapterTableView _view;
        private IChapterModel _model;


        public Task<bool> Create(Chapter chapter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int chapterId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(int chapterId, Chapter newChapter)
        {
            throw new NotImplementedException();
        }

       
        public async Task RefreshUI()
        {
            await _view.OnChapterModelUpdated();
            int? chapters = await _model.GetChapterCountFromAuthor(_session.Id); 
            if(chapters != null && chapters > 0)
            {
                _view.DisplayActive(true);
            }
            else
            {
                _view.DisplayActive(false);
            }
        }

        public ChapterTableController(IChapterModel model, TableLayoutPanel tableView, TabControl tabView, Ao3Session session)
        {
            _model = model;
            _view = new ChapterTableView(this, model, tableView, tabView, session);
            _session = session;
        }


    }
}
