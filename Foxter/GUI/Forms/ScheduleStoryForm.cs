﻿using System.Linq;
using Foxter.Controllers.StoryControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Foxter.AO3;
using System.IO;
using Foxter.Models.Base;
using log4net;
using Foxter.Models;
using Foxter.Controllers.ChapterControllers;
using System.Diagnostics;
using Foxter.Utils;

namespace Foxter.Forms
{
    public partial class ScheduleStoryForm : Form
    {
        enum UiBehavior
        {
            kUpdate,
            kCreate
        };
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //Data sources
        private List<BoxItem> _worksDS;
        private List<BoxItem> _chapterDS;
        private int _updateTarget;
        private IChapterController _controller;
        bool _skipUpdate = true;
        UiBehavior _uiBehavior;

        //Create ctor
        public ScheduleStoryForm(IChapterController controller)
        {
            InitializeComponent();
            mainContainer.Appearance = TabAppearance.FlatButtons;
            mainContainer.ItemSize = new Size(0, 1);
            mainContainer.SizeMode = TabSizeMode.Fixed;
            _worksDS = new List<BoxItem>();
            _chapterDS = new List<BoxItem>();
            _uiBehavior = UiBehavior.kCreate;
            deleteButton.Visible = false;
            _controller = controller;
        }

        //Update ctor
        public ScheduleStoryForm(IChapterController controller, int updateTarget)
        {
            _logger.Info("created ScheduleStoryForm");
            InitializeComponent();
            mainContainer.Appearance = TabAppearance.FlatButtons;
            mainContainer.ItemSize = new Size(0, 1);
            mainContainer.SizeMode = TabSizeMode.Fixed;
            _worksDS = new List<BoxItem>();
            _chapterDS = new List<BoxItem>();
            _uiBehavior = UiBehavior.kUpdate;
            _controller = controller;
            _updateTarget = updateTarget;
            deleteButton.Visible = true;
        }


        //Methods
        public int? GetSelectedWorkId()
        {
            var selected = worksComboBox.SelectedValue;
            if (selected == null) return null;
            return (int)selected;
        }

        public void PopulateWorksBox(List<BoxItem> items)
        {
            _logger.Info($"populated works box with data: {ListToString<BoxItem>.Convert(items)}");
            var source = new AutoCompleteStringCollection();
            _worksDS.Clear();
            _worksDS.AddRange(items);
            worksComboBox.DataSource = null;
            worksComboBox.DataSource = _worksDS;
            worksComboBox.DisplayMember = "DisplayField";
            worksComboBox.ValueMember = "Id";
        }

        public void PopulateChaptersBox(List<BoxItem> items)
        {
            _logger.Info($"populated chapters box with data: {ListToString<BoxItem>.Convert(items)}");
            _chapterDS.Clear();
            _chapterDS.AddRange(items);
            chapterComboBox.DataSource = null;
            chapterComboBox.DataSource = _chapterDS;
            chapterComboBox.DisplayMember = "DisplayField";
            chapterComboBox.ValueMember = "Id";
            chapterComboBox.Enabled = chapterComboBox.Items.Count > 0;
        }


        //Event handlers
        private async void deleteButton_Click(object sender, EventArgs e)
        {
            _logger.Info("delete story button clicked");
            if (await _controller.Delete(_updateTarget) == false)
            {
                MessageBox.Show(
                        $"Failed to cancel the upload task for '{chapterComboBox.Text}'",
                        "Delete task failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                      );
            }
            Close();
        }


        private async Task HandleStoryNotFound() {
            DialogResult choice = MessageBox.Show(
                "This draft no longer exists in Archive of Our Own. Do you wish to remove it from the upload scheduler",
                "Draft not found",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question
                );

            if(choice == DialogResult.Yes )
            {
                bool success = await _controller.Delete(_updateTarget);
                if(!success) {
                    _logger.Warn($"user requested a chapter({_updateTarget}) to be deleted, but the model failed to be updated");
                    //DRY!!!
                    MessageBox.Show(
                        $"Failed to cancel the upload task for '{chapterComboBox.Text}'",
                        "Delete task failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                      );
                }
                else
                {
                    _logger.Info("chapter deleted");
                }

            }
        }


        private async void ScheduleStoryForm_Load(object sender, EventArgs e)
        {
            try
            {
                await _controller.RefreshUI();
                mainContainer.SelectedIndex++;
                _skipUpdate = false;

            }
            catch (HttpRequestException ex)
            {
                if(ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    _logger.Warn($"chapter id:${_updateTarget} no longer exists in AO3");
                    await HandleStoryNotFound();
                }
                else
                {
                    _logger.Error("http error: " + ex.Message);
                    MessageBox.Show(
                    ex.Message,
                    "Request Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                }
                Close();
                
            }
        }

        private async void scheduleButton_Click(object sender, EventArgs e)
        {
            _logger.Info("schedule chapter button clicked");
            if (chapterComboBox.SelectedIndex == -1)
            {
                _logger.Warn("cannot schedule story because no chapter was selected");
                return;
            }

            //Ensure you cant set past dates
            if(publishingDatePicker.Value < DateTime.Now) {
                MessageBox.Show(
                    "A publishing date for a chapter cannot be set in the past",
                    "Invalid publishing date",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }


            var pdc = publishingDatePicker.Value;
            var truncatedUploadDate = pdc.Date + new TimeSpan(pdc.Hour, pdc.Minute, 0);
            if (_uiBehavior == UiBehavior.kCreate)
            {
                _logger.Info("creating new upload task");
                var chapter = new Chapter();
                chapter.StoryTitle = worksComboBox.Text;
                chapter.ChapterTitle = chapterComboBox.Text;
                chapter.ChapterId = (int)chapterComboBox.SelectedValue;
                chapter.StoryId = (int)worksComboBox.SelectedValue;
                chapter.PublishingDate = truncatedUploadDate;
                //authorid is set by the controller
                if (await _controller.Create(chapter) == false)
                {
                    MessageBox.Show(
                        $"Upload task for '{chapterComboBox.Text}' couldn't be created",
                        "Scheduling failed.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                      );
                }
                this.Close();
            }
            else if (_uiBehavior == UiBehavior.kUpdate)
            {
                _logger.Info("updating existing upload task");
                var chapter = new Chapter();
                chapter.StoryTitle = worksComboBox.Text;
                chapter.ChapterTitle = chapterComboBox.Text;
                chapter.ChapterId = (int)chapterComboBox.SelectedValue;
                chapter.StoryId = (int)worksComboBox.SelectedValue;
                chapter.PublishingDate = truncatedUploadDate;
                //authorid is set by the controller
                if (await _controller.Update(_updateTarget, chapter) == false)
                {
                    MessageBox.Show(
                        $"Upload task for '{chapterComboBox.Text}' couldn't be updated",
                        "Scheduling failed.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                      );
                }
                this.Close();
            }
        }


        private async void worksComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //This prevents the event fired whe first registering data bindings
            //from trying to refresh the view BEFORE it is fully initialized
            if (_skipUpdate) return;
            _logger.Info("works index changed, requesting ui update");
            await _controller.RefreshUI();
        }

        private void worksComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            worksComboBox.DroppedDown = true;
            if (char.IsControl(e.KeyChar)) return;
            string str = worksComboBox.Text.Substring(0, worksComboBox.SelectionStart) + e.KeyChar;
            int index = worksComboBox.FindStringExact(str);
            if (index == -1) index = worksComboBox.FindString(str);
            worksComboBox.SelectedIndex = index;
            worksComboBox.SelectionStart = str.Length;
            worksComboBox.SelectionLength = worksComboBox.Text.Length - worksComboBox.SelectionStart;
            e.Handled = true;
        }

        private void chapterComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            chapterComboBox.DroppedDown = true;
            if (char.IsControl(e.KeyChar)) return;
            string str = chapterComboBox.Text.Substring(0, chapterComboBox.SelectionStart) + e.KeyChar;
            int index = chapterComboBox.FindStringExact(str);
            if (index == -1) index = chapterComboBox.FindString(str);
            chapterComboBox.SelectedIndex = index;
            chapterComboBox.SelectionStart = str.Length;
            chapterComboBox.SelectionLength = chapterComboBox.Text.Length - chapterComboBox.SelectionStart;
            e.Handled = true;
        }

        private void openInAo3Button_Click(object sender, EventArgs e)
        {
            var selectedWorkId = worksComboBox.SelectedValue;
            var selectedChapterId = chapterComboBox.SelectedValue;
            if (selectedWorkId != null && selectedChapterId != null)
            {
                var workId = (int)selectedWorkId;
                var chapterId = (int)selectedChapterId;
                Process.Start("explorer", $"https://archiveofourown.org/works/{workId}/chapters/{chapterId}/edit");
            }

        }
    }

    public class BoxItem
    {
        public string DisplayField { get; set; }
        public int Id { get; set; }
        public BoxItem(string displayName, int id)
        {
            DisplayField = displayName;
            Id = id;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"DisplayField=\"{DisplayField}\", ");
            sb.Append($"Id={Id}");
            return sb.ToString();
        }
    }
}