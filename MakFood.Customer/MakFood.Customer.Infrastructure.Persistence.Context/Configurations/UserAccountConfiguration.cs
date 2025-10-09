using MakFood.Customer.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakFood.Customer.Infrastructure.Persistence.Context.Configurations
{
    public class UserAccountConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(EntityTypeBuilder<UserAccount> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.OwnsOne(c => c.AccountInformation);
            builder.OwnsOne(c => c.IdentityInformation);
            builder.OwnsOne(c => c.ContactInformation);

            builder.HasMany(c => c.Addresses)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
