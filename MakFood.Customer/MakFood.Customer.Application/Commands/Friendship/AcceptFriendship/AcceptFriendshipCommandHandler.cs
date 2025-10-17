using MakFood.Customer.Domain.FriendshipAggregate.Contracts;
using MakFood.Customer.Infrastructure.Persistence.Context.Transactions;
using MakFood.Customer.Infrastructure.Substructure.Exceptions;
using MediatR;

namespace MakFood.Customer.Application.Commands.Friendship.AcceptFriendship
{
    public class AcceptFriendshipCommandHandler : IRequestHandler<AcceptFriendshipCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFriendshipRepository _friendshipRepository;

        public AcceptFriendshipCommandHandler(IUnitOfWork unitOfWork, IFriendshipRepository friendshipRepository)
        {
            _unitOfWork = unitOfWork;
            _friendshipRepository = friendshipRepository;
        }

        public async Task Handle(AcceptFriendshipCommand command, CancellationToken ct)
        {
            var targetFriendship = await _friendshipRepository.GetFriendshipById(command.FriendshipId, ct);
            FriendshipValidator(targetFriendship);
            if (targetFriendship!.RecieverId != command.UserId) throw new ForbbidenDomainException("Just Reciever can Change The request state");

            targetFriendship.Accept();

            await _unitOfWork.Commit(ct);

            
            
        }

        #region Validator

        private void FriendshipValidator(Domain.FriendshipAggregate.Friendship? friendship)
        {
            if (friendship == null) throw new Exception("Friendship not found");
        }

        
        

        #endregion

    }
}
