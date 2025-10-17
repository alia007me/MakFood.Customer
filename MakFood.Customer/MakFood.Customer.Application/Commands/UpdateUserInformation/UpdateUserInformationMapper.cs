using MakFood.Customer.Domain.UserAggregate;

namespace MakFood.Customer.Application.Commands.UpdateUserInformation
{
    public static class UpdateUserInformationMapper
    {
        public static IdentityInformation ToModel(UpdateUserInformationCommand command)
        {
            return new IdentityInformation(command.FirstName, command.LastName, command.BirthDate);
        }
    }

}



