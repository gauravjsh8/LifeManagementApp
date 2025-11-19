using System;
using System.IO;

namespace LifeManagementApp
{
    public partial class NotePage : ContentPage
    {
        private Note currentNote;

        public NotePage(Note note = null)
        {
            InitializeComponent();
            currentNote = note;

            if (note != null)
            {
                Title = "Edit Note";
                NoteEditor.Text = note.Text;
            }
            else
            {
                Title = "New Note";
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NoteEditor.Text))
                return;

            if (currentNote == null)
                await _noteService.AddAsync(NoteEditor.Text);
            else
                currentNote.Text = NoteEditor.Text;
            await _noteService.UpdateAsync(currentNote);

            await Navigation.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (currentNote != null)
                await _noteService.DeleteAsync(currentNote);

            await Navigation.PopAsync();
        }
    }
}