using MakFood.Customer.Application.Commands.User.RegisterUser;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace MakFood.Customer.Application.Commands.Login
{
    public record LoginCommand(string phonenumber, string FirstName) : IRequest<string>;
}
