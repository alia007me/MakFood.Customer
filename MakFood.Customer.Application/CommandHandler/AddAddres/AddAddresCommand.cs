using MakFood.Customer.Domain.Models.Entities.User;
using MediatR;

namespace MakFood.Customer.Application.CommandHandler.AddAddres
{
    public record AddAddresCommand(
        Guid UserId,string Title, string StreetAddres, uint HouseNumber
        ):IRequest<Guid>;


}
