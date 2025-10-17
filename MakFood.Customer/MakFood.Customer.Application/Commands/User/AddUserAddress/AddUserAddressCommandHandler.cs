using MakFood.Customer.Domain.UserAggregate;
using MakFood.Customer.Domain.UserAggregate.Contracts;
using MakFood.Customer.Infrastructure.Persistence.Context.Transactions;
using MediatR;

namespace MakFood.Customer.Application.Commands.User.AddUserAddress
{
    public class AddUserAddressCommandHandler : IRequestHandler<AddUserAddressCommand, AddUserAddressCommandRespone>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddUserAddressCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddUserAddressCommandRespone> Handle(AddUserAddressCommand command, CancellationToken ct)
        {
            var user = await _userRepository.GetUserById(command.UserId, ct);
            UserNullcheck(user);

            AddUserAddressCommandRespone response = new AddUserAddressCommandRespone();

            var newAddress = AddUserAddressMapper.ToModel(command);
            user.AddAddress(newAddress);

            await _unitOfWork.Commit(ct);

            response.Massage = "your Address successfully Added";

            return response;
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


