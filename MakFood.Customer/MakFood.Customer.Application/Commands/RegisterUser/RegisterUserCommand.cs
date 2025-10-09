using MediatR;

namespace MakFood.Customer.Application.Commands.RegisterUser
{
    public record RegisterUserCommand : IRequest<RegisterUserCommandResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly? BirthDate { get; set; }

        public string PhoneNumber { get; set; }
        public string? Mail { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
