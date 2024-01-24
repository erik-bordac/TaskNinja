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
        }
    }
}
