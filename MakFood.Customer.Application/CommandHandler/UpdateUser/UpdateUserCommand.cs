using MediatR;


namespace MakFood.Customer.Application.CommandHandler.UpdateUser
{
    public record UpdateUserCommand(
        Guid Id,string? FirstName, string? LastName,
        Guid? AddresId,string? AddresTitle, string? StreetAddres,
        uint? HouseNumber, uint? UnitNo, string? PostalCode
        ):IRequest<UpdateUserInfoCommandResponse>;
}
