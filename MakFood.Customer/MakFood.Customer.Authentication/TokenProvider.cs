using Microsoft.Extensions.Configuration;
using MakFood.Customer.Domain.UserAggregate;

namespace MakFood.Customer.Infrestructure.Authentication
{
    internal sealed class TokenProvider(IConfiguration configuration)
    {
        public string Create(UserAccount user)
        {
            string secretKey = configuration["Jwt:Secret"];
            
        }
    }
}
