using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Application.CommandHandler.CreateUser
{
    public record CreateUserCommand(
        string UserName, string Password, string ConfirmPassword,
        string FirstName, string LastName, string PhoneNumber
        ) : IRequest<CreateUserCommandResponse>;

}
