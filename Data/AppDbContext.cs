using Microsoft.EntityFrameworkCore;
using LifeManagementApp.Models;

namespace LifeManagementApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }

        private string _dbPath;

        public AppDbContext()
        {
            var folder = FileSystem.AppDataDirectory;
            _dbPath = Path.Combine(folder, "lma.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Filename={_dbPath}");
    }
}