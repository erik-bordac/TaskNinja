using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskNinja.Models;

namespace TaskNinja.Configurations
{
    public class TodoTaskConfiguration : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Status).HasConversion(v => v.ToString(), v => (Status)Enum.Parse(typeof(Status), v));
            builder.Property(x => x.Priority).HasConversion(v => v.ToString(), v => (Priority)Enum.Parse(typeof(Priority), v));
            
            // dummy data
            builder.HasData(new List<TodoTask> 
            {
                new TodoTask
                {
                    ID = 1,
                    Name = "Task 1",
                    Description = "Description for Task 1",
                    CreatedDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(-7),
                    Status = Status.InProgress,
                    Priority = Priority.High
                },
                new TodoTask
                {
                    ID = 2,
                    Name = "Task 2",
                    Description = "Description for Task 2",
                    CreatedDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(14),
                    Status = Status.NotStarted,
                    Priority = Priority.Medium
                },
                new TodoTask
                {
                    ID = 3,
                    Name = "Task 3",
                    Description = "Description for Task 3",
                    CreatedDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(21),
                    Status = Status.Completed,
                    Priority = Priority.Low
                },
                new TodoTask
                {
                    ID = 4,
                    Name = "Task 4",
                    Description = "Description for Task 4",
                    CreatedDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(-30),
                    Status = Status.InProgress,
                    Priority = Priority.High
                },
                new TodoTask
                {
                    ID = 5,
                    Name = "Task 5",
                    Description = "Description for Task 5",
                    CreatedDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(10),
                    Status = Status.Completed,
                    Priority = Priority.Medium
                },
                new TodoTask
                {
                    ID = 6,
                    Name = "Task 6",
                    Description = "Description for Task 6",
                    CreatedDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(-2),
                    Status = Status.NotStarted,
                    Priority = Priority.Low
                },
                new TodoTask
                {
                    ID = 7,
                    Name = "Task 7",
                    Description = "Description for Task 7",
                    CreatedDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(21),
                    Status = Status.InProgress,
                    Priority = Priority.Medium
                },
                new TodoTask
                {
                    ID = 8,
                    Name = "Task 8",
                    Description = "Description for Task 8",
                    CreatedDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(30),
                    Status = Status.NotStarted,
                    Priority = Priority.Low
                },
                new TodoTask
                {
                    ID = 9,
                    Name = "Task 9",
                    Description = "Description for Task 9",
                    CreatedDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(7),
                    Status = Status.Completed,
                    Priority = Priority.High
                },
                new TodoTask
                {
                    ID = 10,
                    Name = "Task 10",
                    Description = "Description for Task 10",
                    CreatedDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(14),
                    Status = Status.InProgress,
                    Priority = Priority.Medium
                } 
            }); 
        }
    }
}
