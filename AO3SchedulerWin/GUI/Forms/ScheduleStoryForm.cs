using AO3SchedulerWin.Models.AuthorModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AO3SchedulerWin.Forms
{
    public partial class ScheduleStoryForm : Form
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IAuthorModel _authorModel;
        private Ao3Session _session;

        public ScheduleStoryForm()
        {
            InitializeComponent();
            _authorModel = new AuthorLocalModel();


            /*mainContent.Appearance = TabAppearance.FlatButtons;
            mainContent.ItemSize = new Size(0, 1);
            mainContent.SizeMode = TabSizeMode.Fixed;*/
        }



        private async Task<bool> LoadSession()
        {
            var author = _authorModel.GetActiveAuthor();
            if (author != null)
            {
                try
                {
                    _session = await Ao3Session.CreateSession(author.Name, author.Password);
                    if (_session == null)
                    {
                        _logger.Warn("Could not create AO3 session");
                        MessageBox.Show(
                            $"Could not log into '{author.Name}' Please refresh your login an try again.",
                            "Login Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                            );
                        return false;
                    }
                    return true;
                }
                catch (HttpRequestException ex)
                {
                    _logger.Error(ex);
                }
                catch (Ao3GenericException ex)
                {
                    _logger.Error(ex);
                }
            }
            else
            {
                _logger.Error("No logged user in form");
            }
            return false;
        }

        private async Task<bool> LoadStories()
        {
            try
            {
                var works = await _session.GetAllAuthorStories();
                if (works != null)
                {
                    foreach (Ao3Work work in works)
                    {
                        worksComboBox.Items.Add(work.WorkTitle);
                    }
                    return true;
                }
            }
            catch (Ao3GenericException ex)
            {
                _logger.Error(ex.Message);
            }
            catch (HttpRequestException ex)
            {
                _logger.Error(ex.Message);
            }

            return false;
        }


        //Form Events
        private async void ScheduleStoryForm_Load(object sender, EventArgs e)
        {
            if (await LoadSession() == false) Close();
            if (await LoadStories() == false) Close();
            else mainContent.SelectedIndex = 1;
        }
    }
}
