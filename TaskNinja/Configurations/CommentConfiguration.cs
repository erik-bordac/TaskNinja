using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskNinja.Models;

namespace TaskNinja.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasData(new List<Comment>
            {
                new Comment
                {
                    ID = 1,
                    Content = "First comment on Task 1",
                    CreatedDate = DateTime.Now,
                    TodoTaskID =24 
                },
                new Comment
                {
                    ID = 2,
                    Content = "Another comment on Task 1",
                    CreatedDate = DateTime.Now,
                    TodoTaskID =24 
                },
                new Comment
                {
                    ID = 3,
                    Content = "Comment on Task 2",
                    CreatedDate = DateTime.Now,
                    TodoTaskID =25 
                }
            });
        }
    }
}
