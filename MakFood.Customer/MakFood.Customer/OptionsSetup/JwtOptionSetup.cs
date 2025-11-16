using MakFood.Customer.Application.Commands.Login;
using Microsoft.Extensions.Options;

namespace MakFood.Customer.JwtOptionsSetup
{
    public class JwtOptionSetup : IConfigureOptions<JwtOptions>
    {
        private const string SectionName = "Jwt";
        private readonly IConfiguration _configuration;

        public JwtOptionSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(JwtOptions options)
        {
            _configuration.GetSection(SectionName).Bind(options);
        }
    }
}
