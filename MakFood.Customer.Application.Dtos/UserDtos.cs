namespace MakFood.Customer.Application.Dtos
{
    public record UserDtos(
        string UserName,
        string Password,
        string RePassword,
        string FirstName,
        string LastName,
        string PhoneNumber
        );

    
}
