using Chala.backend.Infrastructure.Entities.DB;
using Microsoft.EntityFrameworkCore;

namespace Chala.backend.Data.SQL
{
    public class ChalaDbContext : DbContext
    {
        public ChalaDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Routine> Routines { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TodoTask> TodoTasks { get; set; }

    }
}
