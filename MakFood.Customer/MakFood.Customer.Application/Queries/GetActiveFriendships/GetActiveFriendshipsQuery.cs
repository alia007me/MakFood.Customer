using MakFood.Customer.Application.Queries.GetActiveFriendships;
using MediatR;

namespace MakFood.Customer.Application.Queries.GetRequests
{
    public class GetActiveFriendshipsQuery : IRequest<List<GetActiveFriendshipsDto>>
    {
        public Guid UserId { get; set; }
    }


}

