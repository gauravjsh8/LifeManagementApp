using LifeManagementApp.Interfaces;
using LifeManagementApp.Models;
using LifeManagementApp.Data;
using Microsoft.EntityFrameworkCore;

namespace LifeManagementApp.Services
{
    public class NoteService : INoteService
    {
        public async Task<List<Note>> GetAllAsync()
        {
            using var db = new AppDbContext();
            return await db.Notes
                .OrderByDescending(n => n.Date)
                .ToListAsync();
        }

        public async Task AddAsync(string text)
        {
            using var db = new AppDbContext();
            var note = new Note { Text = text };
            db.Notes.Add(note);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Note note)
        {
            using var db = new AppDbContext();
            db.Notes.Update(note);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Note note)
        {
            using var db = new AppDbContext();
            db.Notes.Remove(note);
            await db.SaveChangesAsync();
        }
    }
}