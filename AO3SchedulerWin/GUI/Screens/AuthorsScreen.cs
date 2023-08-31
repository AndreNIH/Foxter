using AO3SchedulerWin.Controllers.AuthorControllers;
using AO3SchedulerWin.Models.AuthorModels;
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
        private IAuthorModel _model = new AuthorTestModel();

        public AuthorsScreen()
        {
            InitializeComponent();
            _tableController = AuthorCoordinator.Get.MakeCoorinatedObject(
                new AuthorTableController(_model, new AuthorTableView(usersListView))
            );


            _loggedAuthorController = AuthorCoordinator.Get.MakeCoorinatedObject(
                new LoggedAuthorController(_model, new AuthorNameView(userLabel))
            );

            AuthorCoordinator.Get.NotifyAll();


        }

        ~AuthorsScreen()
        {
            AuthorCoordinator.Get.ReleaseCoordinatedObject(_loggedAuthorController);
            AuthorCoordinator.Get.ReleaseCoordinatedObject(_tableController);
        }

        private void AuthorsScreen_Load(object sender, EventArgs e)
        {
            _tableController.RegisterAuthor(99, "Andre1", "123");
            _tableController.RegisterAuthor(1, "Andre2", "123");
            _tableController.RegisterAuthor(2, "Andre3", "123");
            _tableController.RegisterAuthor(3, "Andre4", "123");
            _tableController.RegisterAuthor(4, "Andre5", "123");
            AuthorCoordinator.Get.NotifyAll();


        }

        private void setActiveButton_Click(object sender, EventArgs e)
        {
            var item = usersListView.SelectedItems[0];
            foreach (var author in _model.GetAllAuthors())
            {
                if (author.Name == item.Text)
                {
                    _loggedAuthorController.SetActiveAuthor(author.Id);
                    _loggedAuthorController.UpdateViews();
                }
            }
            //_tableController.SetActiveAuthor(0);

        }
    }
}
