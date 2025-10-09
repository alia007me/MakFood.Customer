using MakFood.Customer.Domain.FriendshipAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakFood.Customer.Infrastructure.Persistence.Context.Configurations
{
    public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.HasMany(c => c.StateHistory)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
