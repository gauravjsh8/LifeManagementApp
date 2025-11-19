using LifeManagementApp.Models;

namespace LifeManagementApp.Interfaces
{
    public interface INoteService
    {
        Task<List<Note>> GetAllAsync();

        Task AddAsync(string text);

        Task UpdateAsync(Note note);

        Task DeleteAsync(Note note);
    }
}