using Microsoft.Data.Entity;
using MVC6_App.Models;

namespace MVC6_App.Models
{
    public class MVC6_AppDbContext : DbContext
    {
        private static bool _created = false;

        public MVC6_AppDbContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<User> User { get; set; }
    }
}
