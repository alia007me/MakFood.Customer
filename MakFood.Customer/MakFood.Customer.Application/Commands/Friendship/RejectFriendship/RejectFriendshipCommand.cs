using MakFood.Customer.Application.Commands.Friendship.FriendshipOperationBase;
using MakFood.Customer.Domain.FriendshipAggregate.Contracts;
using MakFood.Customer.Infrastructure.Persistence.Context.Transactions;
using MakFood.Customer.Infrastructure.Substructure.Exceptions;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MakFood.Customer.Application.Commands.Friendship.RejectFriendship
{
    public class RejectFriendshipCommand : FriendshipOperationBaseCommand
    {
        
    }

    public class RejectFriendshipCommandValidator : FriendshipOperationBaseCommandValidation
    {
        public RejectFriendshipCommandValidator()
        {
            
        }
    }

    public class RejectFriendshipCommandHandler : IRequestHandler<RejectFriendshipCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFriendshipRepository _friendshipRepository;

        public RejectFriendshipCommandHandler(IUnitOfWork unitOfWork, IFriendshipRepository friendshipRepository)
        {
            _unitOfWork = unitOfWork;
            _friendshipRepository = friendshipRepository;
        }

        public async Task Handle(RejectFriendshipCommand command, CancellationToken ct)
        {
            var targetFriendship = await _friendshipRepository.GetFriendshipById(command.FriendshipId, ct);
            FriendshipValidator(targetFriendship);

            if (command.UserId != targetFriendship!.RecieverId)
            {
                throw new ForbbidenDomainException("Just Reciever can reject friendship request");
            }

            targetFriendship.Reject();

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