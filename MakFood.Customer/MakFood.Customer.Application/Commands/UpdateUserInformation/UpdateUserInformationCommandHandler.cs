using MakFood.Customer.Domain.UserAggregate;
using MakFood.Customer.Domain.UserAggregate.Contracts;
using MakFood.Customer.Infrastructure.Persistence.Context.Transactions;
using MediatR;

namespace MakFood.Customer.Application.Commands.UpdateUserInformation
{
    public class UpdateUserInformationCommandHandler : IRequestHandler<UpdateUserInformationCommand, UpdateUserInformationCommandRespone>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserInformationCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateUserInformationCommandRespone> Handle(UpdateUserInformationCommand command, CancellationToken ct)
        {
            var user = await _userRepository.GetUserById(command.UserId, ct);
            UserNullcheck(user);

            UpdateUserInformationCommandRespone respone = new UpdateUserInformationCommandRespone();

            var newIdentityInformation = UpdateUserInformationMapper.ToModel(command);

            user.IdentityInformation.Update(newIdentityInformation);

            await _unitOfWork.Commit(ct);

            respone.Massage = "User Identity Information Updated!";

            return respone;

        }
        
        #region NullChecks
        private void UserNullcheck(UserAccount user)
        {
            if (user == null)
            {
                throw new Exception("User Not Found!");
            }
        }


        #endregion

    }

}



