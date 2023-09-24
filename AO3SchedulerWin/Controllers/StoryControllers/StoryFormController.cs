using AO3SchedulerWin.Models;
using AO3SchedulerWin.Models.StoryModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AO3SchedulerWin.Controllers.StoryControllers
{
    public class StoryFormController : IStoryController
    {
        log4net.ILog _logger = log4net.LogManager.GetLogger(typeof(StoryFormController));
        IStoryModel _model;
        ComboBox _storyCombobox;
        TextBox _chapterTitleTextbox;
        DateTimePicker _publishDatePicker;
        RichTextBox _chapterSummaryTextbox;
        RichTextBox _chapterNotesTextbox;
        CheckBox _notesAtStartCheckbox;
        CheckBox _notesAtEndCheckbox;
        int? _preloadId;

        public bool DeleteStory(int id)
        {
            throw new NotImplementedException();
        }

        public Story? GetStory(int id)
        {
            throw new NotImplementedException();
        }

        public bool InsertStory(Story story)
        {
            throw new NotImplementedException();
        }

        public bool UpdateStory(int id, Story newStory)
        {
            throw new NotImplementedException();
        }

        public void UpdateViews()
        {
            if(_preloadId != null)
            {
                var story = _model.GetStory(_preloadId.Value);
                if(story != null)
                {
                    _storyCombobox.Items.Add(story.Title);
                    _storyCombobox.SelectedIndex = 1;
                    _chapterTitleTextbox.Text = story.ChapterTitle;
                    _publishDatePicker.Value = story.PublishingDate;
                    _notesAtStartCheckbox.Enabled = story.NotesAtStart;
                    _notesAtEndCheckbox.Enabled = story.NotesAtEnd;
                }
                else
                {
                    _logger.Warn($"Story id '{_preloadId}' was not found in the Story model");
                }

            }
        }

        public StoryFormController(IStoryModel model,
            ComboBox storyCombobox,
            TextBox chapterTitle,
            DateTimePicker publishDate,
            RichTextBox chapterSummary,
            RichTextBox chapterNotes,
            CheckBox notesAtStart,
            CheckBox notesAtEnd,
            int? preloadId)
        {
            _model = model;
            _storyCombobox = storyCombobox;
            _chapterTitleTextbox = chapterTitle;
            _publishDatePicker = publishDate;
            _chapterSummaryTextbox = chapterSummary;
            _chapterNotesTextbox = chapterNotes;
            _notesAtStartCheckbox = notesAtStart;
            _notesAtEndCheckbox = notesAtEnd;
            _preloadId = preloadId;
        }
    }
    
}
