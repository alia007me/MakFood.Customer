using MakFood.Customer.Domain.Base;
using MakFood.Customer.Domain.FriendshipAggregate.Enums;
using MakFood.Customer.Infrastructure.Substructure.Exceptions;

namespace MakFood.Customer.Domain.FriendshipAggregate.States
{
    /// <summary>
    /// حالت دوستی 
    /// </summary>
    public abstract class FriendshipState : BaseEntity<Guid>
    {
        protected FriendshipState()
        {
            Id = Guid.NewGuid();
            CreationDateTime = DateTime.Now;
        }

        /// <summary>
        /// وضعیت دوستی
        /// </summary>
        public abstract FiendshipStatus Status { get; }

        public DateTime CreationDateTime { get; private set; }

        public virtual AcceptedFriendshipState Accept()
        {
            throw new ForbbidenDomainException("Accepting friendship is not valid!");
        }

        public virtual RejectedFriendshipState Reject()
        {
            throw new ForbbidenDomainException("Rejecting friendship status is not valid!");
        }

        public virtual RevokedFriendshipState Revoke()
        {
            throw new ForbbidenDomainException("Rekoving friendship status is not valid!");
        }
    }
}
