using MakFood.Customer.Domain.FriendshipAggregate.Enums;
using MakFood.Customer.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MakFood.Customer.Application.Queries.GetRequests
{
    public class GetRequestQuery : IRequest<List<GetRequestDto>>
    {
        public Guid UserId { get; set; }
    }

    public class GetRequestQueryHandler : IRequestHandler<GetRequestQuery, List<GetRequestDto>>
    {
        private readonly ApplicationContext _context;

        public GetRequestQueryHandler(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<GetRequestDto>> Handle(GetRequestQuery command, CancellationToken ct)
        {
            var recieverId = command.UserId;
            var friendships = await _context.Friendships
                                            .FromSqlInterpolated($@"
                                                    SELECT F.* FROM Friendships AS F
                                                    WHERE F.RecieverId = {recieverId} 
                                                    AND 
                                                    (
                                                        SELECT TOP 1 FS.Discriminator 
                                                        FROM FriendshipState AS FS
                                                        WHERE FS.FriendshipId = F.Id
                                                        ORDER BY FS.CreationDateTime DESC
                                                    ) = 'RequestedFriendshipState'")
                                            .Include(f => f.StateHistory)
                                            .ToListAsync(ct);

            var results = friendships
                          .Select(x => new GetRequestDto(
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

