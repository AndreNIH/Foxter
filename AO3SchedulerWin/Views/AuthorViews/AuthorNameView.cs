using AO3SchedulerWin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Views.AuthorViews
{
    internal class AuthorNameView : IAuthorView
    {
        public void ApplyChanges()
        {
            if (_authorData == null)
            {
                _label.Text = "Not Available";
                _label.ForeColor = Color.DarkGray;
            }
            else
            {
                _label.Text = _authorData.Name;
                _label.ForeColor = Color.FromArgb(153, 0, 0);
            }
        }

        public void QueueViewChange(Author author)
        {
            _authorData = author;
        }

        public AuthorNameView(Label label)
        {
            _label = label;
        }



        Author _authorData;
        Label _label;
    }
}
