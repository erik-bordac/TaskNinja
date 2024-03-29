﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskNinja.Configurations;
using TaskNinja.Models;

namespace TaskNinja.Services
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TodoTaskConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new TeamInviteConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TodoTask> Tasks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<TaskNinja.Models.Team> Team { get; set; } = default!;
        public DbSet<TeamInvite> TeamInvites { get; set; }
    }
}
