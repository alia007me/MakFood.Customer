using MakFood.Customer.Domain.FriendshipAggregate.Enums;
using MediatR;

namespace MakFood.Customer.Application.Queries.GetRequests
{
    public class GetRequestQuery : IRequest<List<GetRequestDto>>
    {
        public Guid UserId { get; set; }
    }


}

