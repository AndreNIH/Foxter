using AO3SchedulerWin.Controllers;
using AO3SchedulerWin.Models;
using AO3SchedulerWin.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Views.ChapterViews.TableView;
using AO3SchedulerWin.Models.Base;

namespace AO3SchedulerWin.Forms
{
    
    public partial class SchedulerScreen : Form, ITableUpdateListener
    {
        public SchedulerScreen(Ao3Client client)
        {
            InitializeComponent();
            _tableView = new ChapterTableView(storyListContainer, _model, this, client);
            _client = client;
        }

        private void reloadScreen()
        {
            mainContainer.SelectedIndex = 1; //storyListContainer.Controls.Count > 0 ? 1 : 0;
        }

        private void schedulePostButton_Click(object sender, EventArgs e)
        {
            var form = new ScheduleStoryForm(_client);
            form.ShowDialog();
            reloadScreen();
        }

        protected override void OnLoad(EventArgs e)
        {
            mainContainer.Appearance = TabAppearance.FlatButtons;
            mainContainer.ItemSize = new Size(0, 1);
            mainContainer.SizeMode = TabSizeMode.Fixed;

            reloadScreen();
        }

        public void NotifyUpdate()
        {
            _controller.UpdateViews();
        }

        private IChapterController _controller;
        private IChapterModel _model;
        private IAuthorModel _authorModel;
        private IChapterView _tableView;
        private Ao3Client _client;
    }

    internal class DeletemeModel : IChapterModel
    {
        public Task Create(Chapter chapter)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int chapterId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Chapter>> GetAllChaptersFromAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<Chapter> GetChapterById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int chapterId, Chapter newChapter)
        {
            throw new NotImplementedException();
        }
    }

    
}
