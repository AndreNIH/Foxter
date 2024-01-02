using AO3SchedulerWin.AO3;
using AO3SchedulerWin.Controllers.AuthorControllers;
using AO3SchedulerWin.GUI.Forms;
using AO3SchedulerWin.Views.AuthorViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AO3SchedulerWin.GUI.Screens
{
    public partial class AuthorsScreen : Form
    {
        private IAuthorController _tableController;
        private IAuthorController _loggedAuthorController;
        private Ao3Client _session;

        public AuthorsScreen(ref Ao3Client session)
        {

        }

        ~AuthorsScreen()
        {

        }

        //Form Events
        private void AuthorsScreen_Load(object sender, EventArgs e)
        {

        }


        //UI Elements
        private void setActiveButton_Click(object sender, EventArgs e)
        {

        }

        private void addAccountButton_Click(object sender, EventArgs e)
        {

        }

        private void removeAccountButton_Click(object sender, EventArgs e)
        {

        }

        private void updateAccountButton_Click(object sender, EventArgs e)
        {

        }
    }
}
