using AO3SchedulerWin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Views
{
    internal class AuthorListViewAdapter : IAuthorView
    {
        public void ApplyChanges()
        {
            _listView.SuspendLayout();
            _listView.Items.Clear();
            foreach (var c in _changesQueue) _listView.Items.Add(c.Name);
            _changesQueue.Clear();
            _listView.ResumeLayout();
        }

        public void QueueViewChange(Author author)
        {
            _changesQueue.Add(author);
        }

        public AuthorListViewAdapter(ListView listView)
        {
            _listView = listView;
        }

        private ListView _listView;
        private List<Author> _changesQueue = new List<Author>();
    }
}
