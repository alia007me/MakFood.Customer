using MakFood.Customer.Application.Commands.UpdateUser;
using MassTransit.Internals;
using MediatR;
using System.Data;
namespace MakFood.Customer.Application.Commands.AddUserAddress
{
    public class AddUserAddressCommand : IRequest<AddUserAddressCommandRespone>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Street { get; set; }
        public uint Plaque { get; set; }
        public string PostalCode { get; set; }
        public uint? UnitNo { get; set; }
    }
}


