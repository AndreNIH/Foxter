using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Views.ChapterViews
{
    public class NewChapterFormView : BaseChapterFormView
    
    {
        IChapterController _controller;
        Form _managedForm;
        DateTimePicker _uploadPickerWidget;
        
        
        
        public NewChapterFormView(
            IChapterController controller,
            Form managedForm,
            Button ao3button,
            ComboBox storyBox, 
            ComboBox chapterBox, 
            DateTimePicker uploadPicker,
            Button okButton,
            Button deleteButton
        ) : base(storyBox, chapterBox, ao3button)
        {
            _controller = controller;
            _uploadPickerWidget = uploadPicker;
            _managedForm = managedForm;
            deleteButton.Enabled = false;
            okButton.Click += OkButton_Click;
            storyBox.SelectedIndexChanged += StoryBox_SelectedIndexChanged;
        }

        public int? GetSelectedStoryId()
        {
            var selectedItem = storyBoxWidget.SelectedItem ;
            if (selectedItem == null) return null;
            return ((BaseChapterFormView.BoxItem)selectedItem).Id;
        }

        private async void StoryBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            try
            {
                _managedForm.Enabled = false;
                await _controller.RefreshUI();
            }catch(HttpRequestException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Network Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                  );
            }
            finally
            {
                _managedForm.Enabled = true;
            }
        }

        private async void OkButton_Click(object? sender, EventArgs e)
        {
            if(storyBoxWidget.SelectedItem == null) return;
            if(chapterBoxWidget.SelectedItem == null) return;
            var newChapter = new Chapter();
            newChapter.StoryTitle = storyBoxWidget.Text;
            newChapter.ChapterTitle = chapterBoxWidget.Text;
            #pragma warning disable CS8605 // Unboxing a possibly null value.
            newChapter.StoryId = (int)storyBoxWidget.SelectedValue;
            newChapter.ChapterId = (int)chapterBoxWidget.SelectedValue;
            #pragma warning restore CS8605 // Unboxing a possibly null value.
            newChapter.PublishingDate = _uploadPickerWidget.Value;
            
            if (await _controller.Create(newChapter) == false)
            {
                MessageBox.Show(
                    $"Upload task for '{storyBoxWidget.Text}' couldn't be created",
                    "Scheduling failed.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                  );
            }
            _managedForm.Close();

        }
    }
}
