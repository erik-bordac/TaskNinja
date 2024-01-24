using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskNinja.Models;

namespace TaskNinja.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            //builder.HasOne(e => e.Author).WithMany().HasForeignKey(e => e.Author);
        }
    }
}
