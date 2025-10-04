using MakFood.Customer.Domain.Models.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MakFood.Customer.Infrstructure.DataAccess.Context.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.OwnsOne(j => j.Account, a =>
            {
                a.Property(p => p.Id);
            });

            builder.OwnsOne(j => j.Contactinfo, p =>
            {
                p.Property(pi => pi.Id);
            });

            builder.OwnsOne(j => j.Identity, p =>
            {
                p.Property(pi => pi.Id);
            });

            builder.OwnsMany(j => j.Addresses, p =>
            {
                p.Property(pi => pi.Id);
            });

        }
    }
}
