using MakFood.Customer.Domain.UserAggregate;

namespace MakFood.Customer.Application.Commands.RegisterUser
{
    public static class RegisterUserMapper
    {
        public static UserAccount ToModel(this RegisterUserCommand command)
        {
            var contact = new ContactInformation(command.PhoneNumber)
            {
                Mail = command.Mail
            };

            var identity = new IdentityInformation(command.FirstName, command.LastName)
            {
                BirthDate = command.BirthDate,
            };

            var account = new AccountInformation();

            return new UserAccount(contact, identity, account);
        }

        public static UserRegisteredMessage ToMessage(this RegisterUserCommand command)
        => new UserRegisteredMessage
        {
            Username = command.Username,
            Password = command.Password,
            ConfirmPassword = command.ConfirmPassword,
        };
    }
}
