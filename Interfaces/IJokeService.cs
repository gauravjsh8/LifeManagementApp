using LifeManagementApp.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace LifeManagementApp.Interfaces
{
    public interface IJokeService
    {
        Task<List<Joke>> GetJokesAsync();
    }
}