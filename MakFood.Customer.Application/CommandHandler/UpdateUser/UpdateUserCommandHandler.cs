using MakFood.Customer.Domain.Interfaces;
using MakFood.Customer.Domain.Models.Entities.User;
using MakFood.Customer.Infrstructure.DataAccess.Context;
using MediatR;
using System.Linq;

namespace MakFood.Customer.Application.CommandHandler.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserInfoCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }



        public async Task<UpdateUserInfoCommandResponse> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var response = new UpdateUserInfoCommandResponse();
            var targetUser = await _userRepository.GetUserById(command.Id);
            if (targetUser == null) throw new ArgumentNullException(nameof(command.Id));

            targetUser.Identity.UpdateFirstName(command.FirstName);
            targetUser.Identity.UpdateLastName(command.LastName);

            var userAddresses = targetUser.Addresses;
            var userAddresid = userAddresses.Select(a => a.Id);

            if (command.AddresId.HasValue && userAddresid.Contains(command.AddresId.Value))
            {
                var targetAddressForChange = userAddresses.FirstOrDefault(a => a.Id == command.AddresId);
                targetAddressForChange.UpdateTitle(command.AddresTitle);
                targetAddressForChange.UpdateStreetAddres(command.StreetAddres);
                targetAddressForChange.UpdateHouseNumber(command.HouseNumber);
                targetAddressForChange.UpdateUnitNo(command.UnitNo);
                targetAddressForChange.UpdatePostalCode(command.PostalCode);

                response.Massage = "your Address successfully Updated";
            }
            else
            {
                Address newAddress = new Address(command.AddresTitle, command.StreetAddres);
                newAddress.UpdateHouseNumber(command.HouseNumber);
                newAddress.UpdateUnitNo(command.UnitNo);
                newAddress.UpdatePostalCode(command.PostalCode);

                targetUser.AddAddres(newAddress);

                response.Massage = "your Address added to your profile";
            }

            await _unitOfWork.SaveChange(cancellationToken);


            return response;

        }
    }
}
