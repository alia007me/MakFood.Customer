using MakFood.Customer.Domain.FriendshipAggregate.Contracts;
using MakFood.Customer.Domain.UserAggregate;
using MakFood.Customer.Domain.UserAggregate.Contracts;
using MakFood.Customer.Infrastructure.Persistence.Context.Transactions;
using MediatR;


namespace MakFood.Customer.Application.Commands.Friendship.CreateFriendship
{
    public class CreateFriendshipCommandHandler : IRequestHandler<CreateFriendshipCommand, CreateFriendshipCommandRespone>
    {
        private readonly IUserRepository _userRepository;
        private readonly IFriendshipRepository _friendshipRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateFriendshipCommandHandler(IUserRepository userRepository, IFriendshipRepository friendshipRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _friendshipRepository = friendshipRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateFriendshipCommandRespone> Handle(CreateFriendshipCommand command, CancellationToken ct)
        {
            CreateFriendshipCommandRespone respone = new CreateFriendshipCommandRespone();

            var senderUser = await _userRepository.GetUserById(command.SenderId,ct);
            UserNullcheck(senderUser,"Sender");

            var receiverUser = await _userRepository.GetUserByPhoneNumber(command.ReceiverPhoneNumber, ct);
            UserNullcheck(receiverUser, "Receiver");

            var checkCanCreateFriendship = await _friendshipRepository.CanCreateFriendship(senderUser!.Id, receiverUser!.Id);
            CheckFriendshipAlreadyExist(checkCanCreateFriendship);



            Domain.FriendshipAggregate.Friendship friendship = new Domain.FriendshipAggregate.Friendship(receiverUser.IdentityInformation.FullName,
                                                                                                         senderUser.IdentityInformation.FullName,
                                                                                                         receiverUser.Id,
                                                                                                         senderUser.Id);

            

            _friendshipRepository.AddFriendship(friendship);

            await _unitOfWork.Commit(ct);

            respone.Id = friendship.Id;

            return respone;


        }

        #region NullChecks
        private void UserNullcheck(UserAccount? user,string sor) //sender Or receiver = sor
        {
            if (user == null) throw new Exception($"{sor}User Not Found!");
        }

        private void CheckFriendshipAlreadyExist(Domain.FriendshipAggregate.Friendship? friendship)
        {
            if (friendship != null) throw new Exception("Friendship between two users exists in requested or created state");
        }


        #endregion
    }

    
}


