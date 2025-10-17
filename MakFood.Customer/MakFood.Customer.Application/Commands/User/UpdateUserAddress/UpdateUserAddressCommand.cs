using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Application.Commands.User.UpdateUserAddress
{
    public class UpdateUserAddressCommand : IRequest<UpdateUserAddressCommandRespone>
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }
        public string Title { get; set; }
        public string Street { get; set; }
        public uint Plaque { get; set; }
        public string PostalCode { get; set; }
        public uint? UnitNo { get; set; }
    }
}
