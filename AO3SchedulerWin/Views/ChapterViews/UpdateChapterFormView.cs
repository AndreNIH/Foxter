using AO3SchedulerWin.Controllers.StoryControllers;
using AO3SchedulerWin.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Views.ChapterViews
{
    /*public class UpdateChapterFormView : BaseChapterFormView
    {
        IChapterController _controller;
        Form _managedForm;
        DateTimePicker _uploadPickerWidget;
        int _updateTarget;

        public UpdateChapterFormView(
            IChapterController controller,
            int updateTarget,
            Form managedForm,
            Button ao3Button,
            ComboBox storyBox,
            ComboBox chapterBox,
            DateTimePicker uploadPicker,
            Button okButton,
            Button deleteButton
        ) : base(storyBox, chapterBox, ao3Button)
        {
            _controller = controller;
            _updateTarget = updateTarget;
            _uploadPickerWidget = uploadPicker;
            _managedForm = managedForm;
            deleteButton.Click += DeleteButton_Click;
            okButton.Click += OkButton_Click;
        }

        
        private async void DeleteButton_Click(object? sender, EventArgs e)
        {
            if(!await _controller.Delete(_updateTarget))
            {
                MessageBox.Show(
                $"Could not delete upload task",
                "Deletion failed.",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
              );
            }
            _managedForm.Close();
        }

        private async void OkButton_Click(object? sender, EventArgs e)
        {
            if (storyBoxWidget.SelectedValue == null) return;
            if (chapterBoxWidget.SelectedValue == null) return;
            var updatedChapter = new Chapter();
            updatedChapter.StoryTitle = storyBoxWidget.SelectedText;
            updatedChapter.ChapterTitle = chapterBoxWidget.SelectedText;
            updatedChapter.StoryId = (int)storyBoxWidget.SelectedValue;
            updatedChapter.ChapterId = (int)chapterBoxWidget.SelectedValue;
            updatedChapter.PublishingDate = _uploadPickerWidget.Value;

            if (await _controller.Update(_updateTarget, updatedChapter) == false)
            {
                MessageBox.Show(
                    $"Upload task for '{storyBoxWidget.SelectedText}' couldn't be updated",
                    "Scheduling failed.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                  );
            }
            _managedForm.Close();
        }

        public void Close()
        {
            _managedForm.Close();
        }
    }*/
}
