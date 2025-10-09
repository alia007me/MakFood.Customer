using MakFood.Customer.Domain.FriendshipAggregate;
using MakFood.Customer.Domain.FriendshipAggregate.Contracts;
using MakFood.Customer.Domain.FriendshipAggregate.Enums;
using MakFood.Customer.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Customer.Infrastructure.Persistence.Repository
{
    public class FriendshipRepository : IFriendshipRepository
    {
        private readonly ApplicationContext _context;

        public FriendshipRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void AddFriendship(Friendship friendship)
        {
            _context.Friendships.Add(friendship);
        }

        public async Task<List<Friendship>> GetAllFriendships(Guid userId, CancellationToken ct)
        {
            return await _context.Friendships
                                 .Include(c => c.StateHistory)
                                 .Where(c => c.SenderId == userId || c.RecieverId == userId)
                                 .Where(c => c.StateHistory.Any(c => c.Status == FiendshipStatus.Accepted))
                                 .ToListAsync(ct);
        }

        public async Task<Friendship?> GetFriendshipById(Guid id, CancellationToken ct)
        {
            return await _context.Friendships.SingleOrDefaultAsync(c => c.Id == id, ct);
        }

        public async Task<List<Friendship>> GetFriendshipRequests(Guid recieverId, CancellationToken ct)
        {
            return await _context.Friendships
                                 .Include(c => c.StateHistory)
                                 .Where(c => c.RecieverId == recieverId)
                                 .Where(c => c.StateHistory.Any(c => c.Status == FiendshipStatus.Requested))
                                 .ToListAsync(ct);
        }
    }
}
