using MakFood.Customer.Application.CommandHandler._ّFriendShipe;
using MakFood.Customer.Domain.Interfaces;
using MakFood.Customer.Domain.Models.Entities.Enums;
using MakFood.Customer.Domain.Models.Entities.Friendship;
using MakFood.Customer.Infrstructure.DataAccess.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace MakFood.Customer.Application.CommandHandler.FriendShip
{
    public class FriendshipCommandHandler : IRequestHandler<FriendshipCommand, bool>
    {
        private readonly IFriendshipRepository _friendshipRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FriendshipCommandHandler(IFriendshipRepository friendshipRepository, IUnitOfWork unitOfWork)
        {
            _friendshipRepository = friendshipRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(FriendshipCommand request, CancellationToken cancellationToken)
        {
            switch (request.Action.ToLower())
            {
                case "add":
                    var friendship = new Friendship(
                        request.NickNameReceiver!,
                        request.NickNameSender!,
                        request.UserId,
                        request.OtherUserId
                    );
                    await _friendshipRepository.AddAsync(friendship);
                    break;

                case "accept":
                    var fAccept = await _friendshipRepository.GetByIdAsync(request.FriendshipId!.Value);
                    fAccept.SetState(MatchingState.Accepted);
                    _friendshipRepository.Update(fAccept);
                    break;

                case "reject":
                    var fReject = await _friendshipRepository.GetByIdAsync(request.FriendshipId!.Value);
                    fReject.SetState(MatchingState.Rejected);
                    _friendshipRepository.Update(fReject);
                    break;

                case "cancel":
                    var fCancel = await _friendshipRepository.GetByIdAsync(request.FriendshipId!.Value);
                    fCancel.Cancel();
                    _friendshipRepository.Update(fCancel);
                    break;

                default:
                    return false;
            }

            await _unitOfWork.SaveChange(cancellationToken);
            return true;
        }
    }
}
