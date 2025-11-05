using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LifeManagementApp.ViewModels
{
    public class MainViewModel : BindableObject
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        public ICommand AddNoteCommand { get; }
        public ICommand AboutCommand { get; }
        public ICommand RefreshCommand { get; }

        public INavigation Navigation { get; set; }

        public MainViewModel(INavigation navigation)
        {
            Navigation = navigation;
            AddNoteCommand = new Command(OnAddNote);
            AboutCommand = new Command(OnAbout);
            RefreshCommand = new Command(LoadNotes);
            LoadNotes();
        }

        private void LoadNotes()
        {
            Notes.Clear();
            foreach (var note in Note.LoadAll().OrderByDescending(n => n.Date))
                Notes.Add(note);
        }

        private async void OnAddNote()
        {
            await Navigation.PushAsync(new NotePage());
        }

        private async void OnAbout()
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}