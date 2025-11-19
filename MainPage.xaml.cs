using LifeManagementApp.Interfaces;
using Microsoft.Maui.Controls;
using System;
using System.Linq;

namespace LifeManagementApp
{
    public partial class MainPage : ContentPage
    {
        private readonly IJokeService _jokeService;

        public MainPage(IJokeService jokeService)
        {
            InitializeComponent();
            _jokeService = jokeService;

            LoadNotes();
        }

        private void LoadNotes()
        {
            NotesList.ItemsSource = await _noteService.GetAllAsync();
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

        private async void OnJokeClicked(object sender, EventArgs e)
        {
            // Pass the IJokeService to the JokePage constructor
            var jokePage = new JokePage(_jokeService);
            await Navigation.PushAsync(jokePage);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadNotes();
        }
    }
}