using MakFood.Customer.Application.Queries.GetActiveFriendships;
using MakFood.Customer.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Customer.Application.Queries.GetRequests
{
    public class GetActiveFriendshipsHandler : IRequestHandler<GetActiveFriendshipsQuery, List<GetActiveFriendshipsDto>>
    {
        private readonly ApplicationContext _context;

        public GetActiveFriendshipsHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<GetActiveFriendshipsDto>> Handle(GetActiveFriendshipsQuery command, CancellationToken ct)
        {
            var UserId = command.UserId;
            var friendships = await _context.Friendships
                                            .FromSqlInterpolated($@"
                                                    SELECT F.* FROM Friendships AS F
                                                    WHERE (F.RecieverId = {UserId} OR F.SenderId = {UserId})
                                                    AND 
                                                    (
                                                        SELECT TOP 1 FS.Discriminator 
                                                        FROM FriendshipState AS FS
                                                        WHERE FS.FriendshipId = F.Id
                                                        ORDER BY FS.CreationDateTime DESC
                                                    ) = 'AcceptedFriendshipState'")
                                            .Include(f => f.StateHistory)
                                            .ToListAsync(ct);

            var results = friendships
                          .Select(x => new GetActiveFriendshipsDto(
            x.Id,
            x.RecieverName,
            x.SenderName,
            x.CurrentState.Status.ToString(),
            x.CreationDateTime))
                          .ToList();

            return results;
        }
    }


}

