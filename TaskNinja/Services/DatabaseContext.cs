using Microsoft.EntityFrameworkCore;
using TaskNinja.Configurations;
using TaskNinja.Models;

namespace TaskNinja.Services
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoTaskConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }

        public DbSet<TodoTask> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
