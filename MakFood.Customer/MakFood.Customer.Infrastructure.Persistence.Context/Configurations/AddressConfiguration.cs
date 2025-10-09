using MakFood.Customer.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakFood.Customer.Infrastructure.Persistence.Context.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(c  => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
        }
    }
}
