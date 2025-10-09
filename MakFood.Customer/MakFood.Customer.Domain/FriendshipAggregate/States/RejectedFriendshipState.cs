using MakFood.Customer.Domain.FriendshipAggregate.Enums;

namespace MakFood.Customer.Domain.FriendshipAggregate.States
{
    public sealed class RejectedFriendshipState : FriendshipState
    {
        internal RejectedFriendshipState() { }

        public override FiendshipStatus Status => FiendshipStatus.Rejected;
    }
}
