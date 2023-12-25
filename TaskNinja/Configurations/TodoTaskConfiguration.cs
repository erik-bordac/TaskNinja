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
            builder.HasData(new List<TodoTask> {
                new TodoTask
                {
                    ID = 1,
                    Name = "Task 1",
                    Description = "Dummy task description 1",
                    CreatedDate = DateTime.Now.AddDays(-5),
                    DueDate = DateTime.Now.AddDays(10),
                    Status = Status.NotStarted,
                    Priority = Priority.Low
                },
                new TodoTask
                {
                    ID = 2,
                    Name = "Task 2",
                    Description = "Dummy task description 2",
                    CreatedDate = DateTime.Now.AddDays(-3),
                    DueDate = DateTime.Now.AddDays(8),
                    Status = Status.InProgress,
                    Priority = Priority.Medium
                },
                new TodoTask
                {
                    ID = 3,
                    Name = "Task 3",
                    Description = "Dummy task description 3",
                    CreatedDate = DateTime.Now.AddDays(-2),
                    DueDate = DateTime.Now.AddDays(-1),
                    Status = Status.NotStarted,
                    Priority = Priority.High
                },
                new TodoTask
                {
                    ID = 4,
                    Name = "Task 4",
                    Description = "Dummy task description 4",
                    CreatedDate = DateTime.Now.AddDays(-7),
                    DueDate = DateTime.Now.AddDays(12),
                    Status = Status.Completed,
                    Priority = Priority.Medium
                },
                new TodoTask
                {
                    ID = 5,
                    Name = "Task 5",
                    Description = "Dummy task description 5",
                    CreatedDate = DateTime.Now.AddDays(-1),
                    DueDate = DateTime.Now.AddDays(5),
                    Status = Status.NotStarted,
                    Priority = Priority.Low
                },
                new TodoTask
                {
                    ID = 6,
                    Name = "Task 6",
                    Description = "Dummy task description 6",
                    CreatedDate = DateTime.Now.AddDays(-4),
                    DueDate = DateTime.Now.AddDays(7),
                    Status = Status.InProgress,
                    Priority = Priority.High
                },
                new TodoTask
                {
                    ID = 7,
                    Name = "Task 7",
                    Description = "Dummy task description 7",
                    CreatedDate = DateTime.Now.AddDays(-6),
                    DueDate = DateTime.Now.AddDays(20),
                    Status = Status.NotStarted,
                    Priority = Priority.Medium
                },
                new TodoTask
                {
                    ID = 8,
                    Name = "Task 8",
                    Description = "Dummy task description 8",
                    CreatedDate = DateTime.Now.AddDays(-2),
                    DueDate = DateTime.Now.AddDays(9),
                    Status = Status.InProgress,
                    Priority = Priority.Low
                },
                new TodoTask
                {
                    ID = 9,
                    Name = "Task 9",
                    Description = "Dummy task description 9",
                    CreatedDate = DateTime.Now.AddDays(-8),
                    DueDate = DateTime.Now.AddDays(14),
                    Status = Status.Completed,
                    Priority = Priority.High
                },
                new TodoTask
                {
                    ID = 10,
                    Name = "Task 10",
                    Description = "Dummy task description 10",
                    CreatedDate = DateTime.Now.AddDays(-1),
                    DueDate = DateTime.Now.AddDays(5),
                    Status = Status.NotStarted,
                    Priority = Priority.High
                } }); 
        }
    }
}
