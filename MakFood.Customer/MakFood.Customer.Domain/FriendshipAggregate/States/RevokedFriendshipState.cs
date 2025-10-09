using MakFood.Customer.Domain.FriendshipAggregate.Enums;

namespace MakFood.Customer.Domain.FriendshipAggregate.States
{
    public sealed class RevokedFriendshipState : FriendshipState
    {
        internal RevokedFriendshipState() { }

        public override FiendshipStatus Status => FiendshipStatus.Revoked;
    }
}
