using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskNinja.Models;

namespace TaskNinja.Configurations
{
    public class TeamInviteConfiguration : IEntityTypeConfiguration<TeamInvite>
    {
        public void Configure(EntityTypeBuilder<TeamInvite> builder)
        {
            builder.HasOne(i => i.Sender)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Recipient)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
