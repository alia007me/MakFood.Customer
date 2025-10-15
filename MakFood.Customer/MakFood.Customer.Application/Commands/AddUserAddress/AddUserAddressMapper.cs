using MakFood.Customer.Domain.UserAggregate;
namespace MakFood.Customer.Application.Commands.AddUserAddress
{
    public static class AddUserAddressMapper
    {
        public static Address ToModel(this AddUserAddressCommand command)
        {
            return new Address(command.Title, command.Street!, (uint)command.Plaque, command.PostalCode, command.UnitNo!) { };
        }


    }
}


