using MakFood.Customer.Domain.UserAggregate;
using Microsoft.Extensions.Options;
using MicrosoftIMT = Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MakFood.Customer.Application.Commands.Login
{
    public sealed class JwtProvider : IJwtProvider
    {
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string Generate(UserAccount user)
        {
            var claims = new Claim[]{
                new(MicrosoftIMT.JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(MicrosoftIMT.JwtRegisteredClaimNames.Name, user.IdentityInformation.FirstName),
                new(MicrosoftIMT.JwtRegisteredClaimNames.PhoneNumber, user.ContactInformation.PhoneNumber)
            };

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
                _options.Issuer,
                _options.Audience,
                claims,
                null,
                DateTime.UtcNow.AddMinutes(_options.ExpiryAfterGenerateByMinutes),
                signingCredentials
                );

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
