using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using MakFood.Customer.Domain.Models.Entities;
using MakFood.Customer.Domain.Models.Entities.User;

namespace MakFood.Customer.Infrstructure.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
                
        }
    }
}
