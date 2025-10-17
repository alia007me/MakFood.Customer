using FluentValidation;
using MakFood.Customer.Application.Commands.Friendship.FriendshipOperationBase;
using MakFood.Customer.Domain.FriendshipAggregate.Contracts;
using MakFood.Customer.Infrastructure.Persistence.Context.Transactions;
using MakFood.Customer.Infrastructure.Substructure.Exceptions;
using MediatR;

namespace MakFood.Customer.Application.Commands.Friendship.RevokeFriendship
{
    public class RevokeFriendshipCommand : FriendshipOperationBaseCommand
    {
        
    }

    public class RevokeFriendshipCommandValidator : FriendshipOperationBaseCommandValidation
    {
        public RevokeFriendshipCommandValidator()
        {
        }
    }

    public class RevokeFriendshipCommandHandler : IRequestHandler<RevokeFriendshipCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFriendshipRepository _friendshipRepository;

        public RevokeFriendshipCommandHandler(IUnitOfWork unitOfWork, IFriendshipRepository friendshipRepository)
        {
            _unitOfWork = unitOfWork;
            _friendshipRepository = friendshipRepository;
        }

        public async Task Handle(RevokeFriendshipCommand command, CancellationToken ct)
        {
            var targetFriendship = await _friendshipRepository.GetFriendshipById(command.FriendshipId,ct);
            FriendshipValidator(targetFriendship);

            if (command.UserId != targetFriendship!.SenderId && command.UserId != targetFriendship.RecieverId)
            {
                throw new ForbbidenDomainException("This Friendship is not for yours");
            }

            targetFriendship.Revoke();

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
