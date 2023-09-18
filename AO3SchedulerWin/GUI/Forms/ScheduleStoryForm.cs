using AO3SchedulerWin.Models;
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

        public ScheduleStoryForm(Ao3Session session)
        {
            InitializeComponent();
            _session = session;
            _authorModel = new AuthorLocalModel();


            /*mainContent.Appearance = TabAppearance.FlatButtons;
            mainContent.ItemSize = new Size(0, 1);
            mainContent.SizeMode = TabSizeMode.Fixed;*/
        }

        private async Task<bool> LoadStories()
        {
            try
            {
                var works = await _session.GetAllAuthorWorks();
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
                MessageBox.Show(
                     ex.Message,
                    "HTTP Request Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
            }

            return false;
        }


        //Form Events
        private async void ScheduleStoryForm_Load(object sender, EventArgs e)
        {
            if(_session != null)
            {
                if (await LoadStories() == false) Close();
                else mainContent.SelectedIndex = 1;
            }
            else
            {
                _logger.Error("session object was null");
                Close();
            }
        }
    }
}
