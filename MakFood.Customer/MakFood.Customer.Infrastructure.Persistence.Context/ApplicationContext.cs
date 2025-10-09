using MakFood.Customer.Domain.FriendshipAggregate;
using MakFood.Customer.Domain.UserAggregate;
using MakFood.Customer.Infrastructure.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Customer.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Friendship> Friendships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserAccountConfiguration).Assembly);
        }
    }
}
