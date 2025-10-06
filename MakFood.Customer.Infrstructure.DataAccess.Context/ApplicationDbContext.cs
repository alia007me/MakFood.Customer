using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using MakFood.Customer.Domain.Models.Entities.Friendship;
using MakFood.Customer.Domain.Models.Entities.User;
using MakFood.Customer.Infrstructure.DataAccess.Context.Configuration;

namespace MakFood.Customer.Infrstructure.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        }
    }
}
