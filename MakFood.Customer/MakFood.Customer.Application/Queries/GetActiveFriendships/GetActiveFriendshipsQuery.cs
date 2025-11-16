using MediatR;

namespace MakFood.Customer.Application.Queries.GetActiveFriendships
{
    public class GetActiveFriendshipsQuery : IRequest<List<GetActiveFriendshipsDto>>
    {
        public Guid UserId { get; set; }
    }


}

