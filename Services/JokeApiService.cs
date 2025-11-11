using LifeManagementApp.Interfaces;
using LifeManagementApp.Models;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LifeManagementApp.Services
{
    public class JokeApiService : IJokeService
    {
        private readonly HttpClient _httpClient;

        public JokeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Joke>> GetJokesAsync()
        {
            var jokes = new List<Joke>();

            string url = "https://v2.jokeapi.dev/joke/Programming?blacklistFlags=nsfw,religious,political,racist,sexist,explicit&amount=3";
            var response = await _httpClient.GetStringAsync(url);
            var json = JsonDocument.Parse(response);

            foreach (var jokeJson in json.RootElement.GetProperty("jokes").EnumerateArray())
            {
                if (jokeJson.TryGetProperty("joke", out var singleJoke))
                    jokes.Add(new OneLinerJoke { Content = singleJoke.GetString()! });
                else
                    jokes.Add(new TwoLinerJoke
                    {
                        Setup = jokeJson.GetProperty("setup").GetString()!,
                        Delivery = jokeJson.GetProperty("delivery").GetString()!
                    });
            }

            return jokes;
        }
    }
}