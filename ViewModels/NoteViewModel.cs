using System.IO;
using System.Windows.Input;

namespace LifeManagementApp.ViewModels
{
    public class NoteViewModel : BindableObject
    {
        private Note currentNote;
        private string text;

        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand DeleteCommand { get; }

        public INavigation Navigation { get; set; }

        public NoteViewModel(INavigation navigation, Note note = null)
        {
            currentNote = note;
            Navigation = navigation;

            if (note != null)
                Text = note.Text;

            SaveCommand = new Command(OnSave);
            DeleteCommand = new Command(OnDelete);
        }

        private async void OnSave()
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;

            if (currentNote == null)
                Note.Save(Text);
            else
                File.WriteAllText(currentNote.Filename, Text);

            await Navigation.PopAsync();
        }

        private async void OnDelete()
        {
            currentNote?.Delete();
            await Navigation.PopAsync();
        }
    }
}