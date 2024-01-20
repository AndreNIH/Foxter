using AO3SchedulerWin.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Views.AuthorViews
{
    public class AuthorLabelViewAdapter : IAuthorView
    {
        Label _label;
        public void Update(Author author)
        {
            _label.Text = author.Name;
        }
        
        public AuthorLabelViewAdapter(Label label) 
        { 
            _label = label;
        }
    }
}
