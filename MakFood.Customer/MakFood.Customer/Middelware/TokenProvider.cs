using MakFood.Customer.Domain.UserAggregate;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JsonWebToken = Microsoft.IdentityModel.JsonWebTokens; 

namespace MakFood.Customer.Infrestructure.Authentication
{
    internal sealed class TokenProvider(IConfiguration configuration)
    {
        public string Create(UserAccount user)
        {
            string secretKey = configuration["Jwt:Secret"]!;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new CaseSensitiveClaimsIdentity
                ([
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, user.IdentityInformation.FirstName),
                    new Claim(JwtRegisteredClaimNames.FamilyName, user.IdentityInformation.LastName),
                ]),

                Expires = DateTime.UtcNow.AddMinutes(configuration.GetValue<int>("Jwt:ExprationInMinutes")),
                SigningCredentials = credential,
                Issuer = configuration["Jwt:Issuer"],
                Audience = configuration["Jwt:Audience"]
            };

            var handler = new JsonWebToken.JsonWebTokenHandler();

            string token = handler.CreateToken(tokenDescriptor);

            return token;
        }
    }
}
