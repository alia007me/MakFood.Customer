using MakFood.Customer.Domain.FriendshipAggregate.States;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakFood.Customer.Infrastructure.Persistence.Context.Configurations
{
    public class FriendshipStateConfiguration : IEntityTypeConfiguration<FriendshipState>
    {
        public void Configure(EntityTypeBuilder<FriendshipState> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.HasDiscriminator()
                   .HasValue<AcceptedFriendshipState>(nameof(AcceptedFriendshipState))
                   .HasValue<RejectedFriendshipState>(nameof(RejectedFriendshipState))
                   .HasValue<RequestedFriendshipState>(nameof(RequestedFriendshipState))
                   .HasValue<RevokedFriendshipState>(nameof(RevokedFriendshipState));

        }
    }
}
