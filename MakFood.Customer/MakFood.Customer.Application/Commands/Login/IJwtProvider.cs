using MakFood.Customer.Domain.UserAggregate;

namespace MakFood.Customer.Application.Commands.Login
{
    public interface IJwtProvider
    {
        string Generate(UserAccount user);
    }
}
