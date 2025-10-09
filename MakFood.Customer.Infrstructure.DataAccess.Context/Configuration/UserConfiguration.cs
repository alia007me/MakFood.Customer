using MakFood.Customer.Domain.Models.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakFood.Customer.Infrstructure.DataAccess.Context.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.OwnsOne(j => j.Account);

            builder.OwnsOne(j => j.Contactinfo);

            builder.OwnsOne(j => j.Identity);

            builder.HasMany(j => j.Addresses)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);
            //builder.Property(c => c.Addresses)
            //       .HasField("_address")
            //       .UsePropertyAccessMode(PropertyAccessMode.PreferFieldDuringConstruction);

        }
    }
}
