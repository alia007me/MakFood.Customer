using MakFood.Customer.Application.Servises;
using MakFood.Customer.Domain.Models.Entities.User;
using MakFood.Customer.Infrstructure.DataAccess.Context;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;


namespace MakFood.Customer.Application.CommandHandler.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,Guid>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserServiceRepository _userService;

        public CreateUserCommandHandler(ApplicationDbContext context, IUserServiceRepository userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await _userService.RegisterUser(request.PhoneNumber);  

            var accountInfo = new AccountInformation();
            var contactInfo = new ContactInformation(request.PhoneNumber);
            var identityInfo = new IdentityInformation(request.FirstName, request.LastName);

            var user = new User(identityInfo,accountInfo,contactInfo);
            _context.Add<User>(user);
            await _context.SaveChangesAsync();

            return user.Id;
        }
    }
}
