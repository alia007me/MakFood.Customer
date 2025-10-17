using MediatR;


namespace MakFood.Customer.Application.Commands.Friendship.CreateFriendship
{

    public class CreateFriendshipCommand : IRequest<CreateFriendshipCommandRespone>
    {
        public Guid SenderId { get; set; }
        public string ReceiverPhoneNumber { get; set; }
    }

    
}


