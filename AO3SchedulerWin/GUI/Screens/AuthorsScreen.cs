using AO3SchedulerWin.Controllers.AuthorControllers;
using AO3SchedulerWin.Models.AuthorModels;
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

namespace AO3SchedulerWin.GUI.Screens
{
    public partial class AuthorsScreen : Form
    {
        private IAuthorController _controller;
        public AuthorsScreen()
        {
            InitializeComponent();
            _controller = new AuthorTableController(
                new AuthorListViewAdapter(usersListView),
                new AuthorTestModel()
            );
        }

        private void AuthorsScreen_Load(object sender, EventArgs e)
        {
            _controller.RegisterAuthor(0, "Andre1", "123");
            _controller.RegisterAuthor(0, "Andre2", "123");
            _controller.RegisterAuthor(0, "Andre3", "123");
            _controller.RegisterAuthor(0, "Andre4", "123");
            _controller.RegisterAuthor(0, "Andre5", "123");
            _controller.UpdateViews();


        }

        private void setActiveButton_Click(object sender, EventArgs e)
        {
            var item = usersListView.SelectedItems[0];
            if (item != null)
            {
                var user = item.SubItems[0].Text;
                loggedUserLabel.Text = $"Logged in as: {user}";
            }

        }
    }
}
