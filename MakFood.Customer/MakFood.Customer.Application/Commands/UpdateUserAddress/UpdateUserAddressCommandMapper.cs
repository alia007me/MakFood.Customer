using MakFood.Customer.Domain.UserAggregate;

namespace MakFood.Customer.Application.Commands.UpdateUserAddress
{
    public static class UpdateUserAddressCommandMapper
    {
        public static Address ToModel(this UpdateUserAddressCommand command)
        {
            return new Address(command.Title,command.Street, command.Plaque,command.PostalCode, command.UnitNo);
        }
    }





}
