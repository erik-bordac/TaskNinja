using Microsoft.EntityFrameworkCore;
using TaskNinja.Models;
using TaskNinja.Services;
using TaskNinja.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace TaskNinja
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/TaskManager");
                options.Conventions.AuthorizeFolder("/TeamsManager");
                options.Conventions.AuthorizeFolder("/Dashboard");
                options.Conventions.AuthorizePage("/TeamInvites");
            });
            builder.Services.AddDefaultIdentity<User>().AddEntityFrameworkStores<DatabaseContext>();
            builder.Services.AddScoped<ITodoTaskService, MyTodoTaskService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITeamsService, TeamsService>();
            builder.Services.AddScoped<ITeamInviteService, TeamInviteService>();
            builder.Services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("DatabaseContext"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
