using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskNinja.Models;

namespace TaskNinja.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.HasOne<TeamInvite>(u => u.Sender)
            //    .WithOne(i => i.Sender)
            //    .HasForeignKey<TeamInvite>(i => i.SenderId);
        }
    }
}
