using MakFood.Customer.Domain.UserAggregate;
using MakFood.Customer.Domain.UserAggregate.Contracts;
using MakFood.Customer.Infrastructure.Persistence.Context.Transactions;
using MediatR;

namespace MakFood.Customer.Application.Commands.RemoveUserAddress
{
    public class RemoveUserAddressCommandHandler : IRequestHandler<RemoveUserAddressCommand, RemoveUserAddressCommandRespone>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveUserAddressCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<RemoveUserAddressCommandRespone> Handle(RemoveUserAddressCommand command, CancellationToken ct)
        {
            var user = await _userRepository.GetUserById(command.UserId,ct);
            UserNullcheck(user);

            var forRemoveAddress = user.Addresses.FirstOrDefault(a => a.Id == command.AddressId);
            AddressNullCheck(forRemoveAddress);

            user.RemoveAddress(forRemoveAddress);

            await _unitOfWork.Commit(ct);

            RemoveUserAddressCommandRespone response = new RemoveUserAddressCommandRespone();

            response.Massage = "your Address successfully deleted";

            return response;

        }

        #region NullChecks
        private void UserNullcheck(UserAccount user)
        {
            if (user == null) throw new Exception("User Not Found!");
            
        }

        private void AddressNullCheck(Address address)
        {
            if (address == null) throw new Exception("User Not Found!");
        }



        #endregion
    }
}
