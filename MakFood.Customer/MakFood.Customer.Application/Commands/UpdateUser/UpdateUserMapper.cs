using MakFood.Customer.Domain.UserAggregate;

namespace MakFood.Customer.Application.Commands.UpdateUser
{
    public static class UpdateUserMapper
    {
        public static Address ToModel(this UpdateUserCommand command)
        {
            return new Address(command.AddressTitle, command.AddressStreet!, (uint)command.AddressPlaque, command.AddressPostalCode!,command.AddressUnitNo) { };
        }
    }
}

