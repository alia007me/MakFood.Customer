using MakFood.Customer.Domain.UserAggregate;
using MakFood.Customer.Domain.UserAggregate.Contracts;
using MakFood.Customer.Infrastructure.Persistence.Context.Transactions;
using MediatR;

namespace MakFood.Customer.Application.Commands.UpdateUserAddress
{
    public class UpdateUserAddressCommandHandler : IRequestHandler<UpdateUserAddressCommand, UpdateUserAddressCommandRespone>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserAddressCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateUserAddressCommandRespone> Handle(UpdateUserAddressCommand command, CancellationToken ct)
        {
            var user = await _userRepository.GetUserById(command.UserId, ct);
            UserNullcheck(user);

            var forUpdateAddress = user.Addresses.FirstOrDefault(a => a.Id == command.AddressId);

            AddressNullCheck(forUpdateAddress);

            var updatedAddress = UpdateUserAddressCommandMapper.ToModel(command);

            forUpdateAddress.UpdateAddress(updatedAddress);

            UpdateUserAddressCommandRespone response = new UpdateUserAddressCommandRespone();

            await _unitOfWork.Commit(ct);

            response.Massage = "your Address successfully Updated";

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
