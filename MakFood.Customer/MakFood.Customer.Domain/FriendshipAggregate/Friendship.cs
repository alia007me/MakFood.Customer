using MakFood.Customer.Domain.Base;
using MakFood.Customer.Domain.FriendshipAggregate.Enums;
using MakFood.Customer.Domain.FriendshipAggregate.States;
using MakFood.Customer.Infrastructure.Substructure.Exceptions;

namespace MakFood.Customer.Domain.FriendshipAggregate
{
    public class Friendship : BaseEntity<Guid>
    {
        private List<FriendshipState> _stateHistory = new List<FriendshipState>();

        private Friendship() { }
        public Friendship(string recieverName, string senderName, Guid recieverId, Guid senderId)
        {
            CheckRecieverNameNullOrEmpty(recieverName);
            CheckSenderNameNullOrEmpty(senderName);

            Id = Guid.NewGuid();
            RecieverName = recieverName;
            SenderName = senderName;
            RecieverId = recieverId;
            SenderId = senderId;
        }

        public string RecieverName { get; private set; }
        public string SenderName { get; private set; }
        public Guid RecieverId { get; private set; }
        public Guid SenderId { get; private set; }

        public bool Activated => CurrentState.Status == FiendshipStatus.Accepted;

        public IReadOnlyCollection<FriendshipState> StateHistory => _stateHistory.AsReadOnly();
        public FriendshipState CurrentState => _stateHistory.OrderByDescending(c => c.CreationDateTime).First();

        #region Validations

        private void CheckRecieverNameNullOrEmpty(string recieverName)
        {
            if (string.IsNullOrWhiteSpace(recieverName))
                throw new ValidationFailedDomainException("Reciever name can not be empty!");
        }

        private void CheckSenderNameNullOrEmpty(string senderName)
        {
            if (string.IsNullOrWhiteSpace(senderName))
                throw new ValidationFailedDomainException("Sender name can not be empty!");
        }

        #endregion

        #region Behaviors

        public void Accept()
        {
            _stateHistory.Add(CurrentState.Accept());
        }

        public void Reject()
        {
            _stateHistory.Add(CurrentState.Reject());
        }

        public void Revoke()
        {
            _stateHistory.Add(CurrentState.Revoke());
        }

        #endregion
    }
}

