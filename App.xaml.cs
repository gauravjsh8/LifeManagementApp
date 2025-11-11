using Microsoft.Maui.Controls;
using LifeManagementApp.Services;

namespace LifeManagementApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage(
                new JokeApiService(new System.Net.Http.HttpClient())
            ));
        }
    }
}