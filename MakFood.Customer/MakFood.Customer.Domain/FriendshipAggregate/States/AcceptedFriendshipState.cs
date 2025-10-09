using MakFood.Customer.Domain.FriendshipAggregate.Enums;

namespace MakFood.Customer.Domain.FriendshipAggregate.States
{
    public sealed class AcceptedFriendshipState : FriendshipState
    {
        internal AcceptedFriendshipState() { }

        public override FiendshipStatus Status => FiendshipStatus.Accepted;

        public override RevokedFriendshipState Revoke()
        {
            return new RevokedFriendshipState();
        }
    }
}
