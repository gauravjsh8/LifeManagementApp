using LifeManagementApp.Interfaces;
using LifeManagementApp.Models;

namespace LifeManagementApp
{
    public partial class JokePage : ContentPage
    {
        private readonly IJokeService _jokeService;

        public JokePage(IJokeService jokeService)
        {
            InitializeComponent();
            _jokeService = jokeService;
        }

        private async void OnLoadJokesClicked(object sender, EventArgs e)
        {
            var jokes = await _jokeService.GetJokesAsync();
            JokesList.ItemsSource = jokes.Select(j => j.ToString());
        }
    }
}