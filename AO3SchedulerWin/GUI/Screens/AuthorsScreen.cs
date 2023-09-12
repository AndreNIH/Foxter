using AO3SchedulerWin.Controllers.AuthorControllers;
using AO3SchedulerWin.GUI.Forms;
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
        private IAuthorModel _model = new AuthorLocalModel();

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

        //Methods
        async Task TryLogin()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://archiveofourown.org")
            };

            Dictionary<string, string> loginParams = new Dictionary<string, string>();
            loginParams.Add("user[login]", "");
            loginParams.Add("user[password]", "");
            using HttpResponseMessage loginResponse = await httpClient.PostAsync("users/login/", new FormUrlEncodedContent(null));
        }


        
        
        //Form Events
        private void AuthorsScreen_Load(object sender, EventArgs e)
        {

            AuthorCoordinator.Get.NotifyAll();


        }


        //UI Elements
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

        private void addAccountButton_Click(object sender, EventArgs e)
        {
            var form = new Ao3LoginForm();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }
    }
}
