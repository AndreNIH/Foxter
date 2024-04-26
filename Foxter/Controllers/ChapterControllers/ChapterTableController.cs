using Foxter.AO3;
using Foxter.Controllers.StoryControllers;
using Foxter.GUI.ChapterViews.TableView;
using Foxter.Models;
using Foxter.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxter.Controllers.ChapterControllers
{
    public class ChapterTableController : IChapterController
    {
        private ISession _session;
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
            int? chapters = await _model.GetChapterCountFromAuthor(_session.GetId()); 
            if(chapters != null && chapters > 0)
            {
                _view.DisplayActive(true);
            }
            else
            {
                _view.DisplayActive(false);
            }
        }

        public ChapterTableController(IChapterModel model, TableLayoutPanel tableView, TabControl tabView, ISession session)
        {
            _model = model;
            _view = new ChapterTableView(model, tableView, tabView, session);
            _session = session;
        }


    }
}
