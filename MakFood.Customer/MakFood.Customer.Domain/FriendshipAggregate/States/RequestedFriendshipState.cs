using MakFood.Customer.Domain.FriendshipAggregate.Enums;

namespace MakFood.Customer.Domain.FriendshipAggregate.States
{
    public sealed class RequestedFriendshipState : FriendshipState
    {
        internal RequestedFriendshipState() { }

        public override FiendshipStatus Status => FiendshipStatus.Requested;

        public override AcceptedFriendshipState Accept()
        {
            return new AcceptedFriendshipState();
        }

        public override RejectedFriendshipState Reject()
        {
            return new RejectedFriendshipState();
        }
    }
}
