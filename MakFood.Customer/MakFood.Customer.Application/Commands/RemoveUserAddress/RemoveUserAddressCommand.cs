using MediatR;

namespace MakFood.Customer.Application.Commands.RemoveUserAddress
{
    public class RemoveUserAddressCommand : IRequest<RemoveUserAddressCommandRespone>
    {
        public Guid UserId { get; set; }
        public Guid AddressId { get; set; }

    }
}
