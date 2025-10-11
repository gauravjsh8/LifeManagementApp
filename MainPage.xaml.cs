using System;
using System.Linq;

namespace LifeManagementApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadNotes();
        }

        private void LoadNotes()
        {
            NotesList.ItemsSource = Note.LoadAll().OrderByDescending(n => n.Date);
        }

        private async void OnAddNoteClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotePage());
        }

        private async void OnNoteSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Note note)
            {
                await Navigation.PushAsync(new NotePage(note));
                NotesList.SelectedItem = null;
            }
        }

        private async void OnAboutClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadNotes();
        }
    }
}