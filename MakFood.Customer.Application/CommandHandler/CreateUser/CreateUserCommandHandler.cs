using MakFood.Customer.Application.Servises;
using MakFood.Customer.Domain.Interfaces;
using MakFood.Customer.Domain.Models.Entities.User;
using MakFood.Customer.Infrstructure.DataAccess.Context;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;


namespace MakFood.Customer.Application.CommandHandler.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,Guid>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(ApplicationDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await RegisterUser(request.PhoneNumber);  

            var accountInfo = new AccountInformation();
            var contactInfo = new ContactInformation(request.PhoneNumber);
            var identityInfo = new IdentityInformation(request.FirstName, request.LastName);

            var user = new User(identityInfo,accountInfo,contactInfo);
            _context.Add<User>(user);

            await _context.SaveChangesAsync();

            return user.Id;
        }


        private async Task RegisterUser(string phoneNumber)
        {
            var result = await _userRepository.IsUserExistByPhoneNumber(phoneNumber);
            if (result) throw new Exception("this phoneNumber Is already registerd");

        }
    }
}
