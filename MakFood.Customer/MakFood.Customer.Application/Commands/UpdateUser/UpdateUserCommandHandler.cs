using MakFood.Customer.Domain.UserAggregate;
using MakFood.Customer.Domain.UserAggregate.Contracts;
using MakFood.Customer.Infrastructure.Persistence.Context.Transactions;
using MediatR;

namespace MakFood.Customer.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand command, CancellationToken ct)
        {
            var User = await _userRepository.GetUserById(command.UserId, ct);
            UserNullcheck(User);

            User.IdentityInformation.UpdateName(command.FirstName, command.LastName);
            UpdateUserCommandResponse response = new UpdateUserCommandResponse();

            switch (SelectOpration(command))
            {
                case 1:
                    response.Massage = AddAddress(User, command);
                    break;
                case 2:
                    response.Massage = updateAddress(User, command);
                    break;
                case 3:
                    response.Massage = RemoveAddress(User, command);
                    break;

            }
            await _unitOfWork.Commit(ct);

            return response;
        }

        #region Address Operations Methods
        private string AddAddress(UserAccount user, UpdateUserCommand command)
        {
            var newAddress = UpdateUserMapper.ToModel(command);
            user.AddAddress(newAddress);

            return "Address successfully added";
        }
        private string updateAddress(UserAccount user, UpdateUserCommand command)
        {
            var address = user.Addresses.FirstOrDefault(a => a.Id == command.AddressId);
            //AddressNullcheck(address);

            command = FillBlanksOfCommand(address, command);

            var forUpdateAddress = UpdateUserMapper.ToModel(command);
            address.UpdateAddress(forUpdateAddress);


            return "Address successfully updated";
        }
        private string RemoveAddress(UserAccount user, UpdateUserCommand command)
        {
            var forRemoveAddress = user.Addresses.FirstOrDefault(a => a.Id == command.AddressId);
            //AddressNullcheck(forRemoveAddress);
            user.RemoveAddress(forRemoveAddress);

            return "Address successfully removed";
        }

        /// <summary>
        /// عملیات را بسته به مقدار ورودی ها انتخاب می کند
        /// </summary>
        /// <param name="command">ورودی کامند</param>
        /// <remarks>
        /// افزودن = در صورتی که آیدی آدرس خالی باشد
        /// آپدیت = در صورتی که آیدی آدرس پر باشد و بقیه ورودی های آدرس هم پر باشند
        /// حذف = در صورتی که بجز آیدی هیچ کدام از ورودی های آدرس پر نباشند
        /// </remarks>
        /// <returns>اعداد یک تا سه به ترتیب برای عملیات های : افزودن، ویرایش و حذف</returns>
        private uint SelectOpration(UpdateUserCommand command)
        {
            if (!command.AddressId.HasValue)
                return 1; // Add Address
            else if (command.AddressId.HasValue &&
                     string.IsNullOrWhiteSpace(command.AddressTitle) &&
                     string.IsNullOrWhiteSpace(command.AddressStreet) &&
                     !command.AddressPlaque.HasValue &&
                     string.IsNullOrWhiteSpace(command.AddressPostalCode) &&
                     !command.AddressUnitNo.HasValue)
                return 3; // Remove Address
            else if (command.AddressId.HasValue)
                return 2; // Update Address
            else
                return 0; // No Operation
        }

        private UpdateUserCommand FillBlanksOfCommand(Address preAddress,UpdateUserCommand newAddres)
        {
            if (string.IsNullOrWhiteSpace(newAddres.AddressTitle))
                newAddres.AddressTitle = preAddress.Title;

            if (string.IsNullOrWhiteSpace(newAddres.AddressStreet))
                newAddres.AddressStreet = preAddress.Street;

            if (!newAddres.AddressPlaque.HasValue)
                newAddres.AddressPlaque = preAddress.Plaque;

            if (string.IsNullOrWhiteSpace(newAddres.AddressPostalCode))
                newAddres.AddressPostalCode = preAddress.PostalCode;

            if (!newAddres.AddressUnitNo.HasValue)
                newAddres.AddressUnitNo = preAddress.UnitNo;

            return newAddres;
        }
        #endregion
        #region NullChecks
        private void UserNullcheck(UserAccount user)
        {
            if (user == null)
            {
                throw new Exception("User Not Found!");
            }
        }

        //private Address AddressNullcheck(Address address)
        //{
        //    if (address == null)
        //    {
        //        throw new Exception("Address Not Found!");
        //    }
        //    return address;

        //}
        #endregion
    }
}

