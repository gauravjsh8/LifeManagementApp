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
                Note.Save(NoteEditor.Text);
            else
                File.WriteAllText(currentNote.Filename, NoteEditor.Text);

            await Navigation.PopAsync();
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (currentNote != null)
                currentNote.Delete();

            await Navigation.PopAsync();
        }
    }
}
