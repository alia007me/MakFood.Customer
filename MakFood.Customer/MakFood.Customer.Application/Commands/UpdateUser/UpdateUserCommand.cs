using FluentValidation.Internal;
using MakFood.Customer.Application.Commands.RegisterUser;
using MakFood.Customer.Application.Commands.UpdateUser;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MakFood.Customer.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UpdateUserCommandResponse>
    {
        public Guid UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Guid? AddressId { get; set; }
        public string? AddressTitle { get; set; }
        public string? AddressStreet { get; set; }
        public uint? AddressPlaque { get; set; }
        public string? AddressPostalCode { get; set; }
        public uint? AddressUnitNo { get; set; }

    }
}

