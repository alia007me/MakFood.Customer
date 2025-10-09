using MakFood.Customer.Domain.UserAggregate;
using MakFood.Customer.Domain.UserAggregate.Contracts;
using MakFood.Customer.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Customer.Infrastructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddUser(UserAccount user)
        {
            _context.Users.Add(user);
        }

        public async Task<UserAccount?> GetUserById(Guid userId, CancellationToken ct)
        {
            return await _context.Users.SingleOrDefaultAsync(c => c.Id == userId, ct);
        }
    }
}
