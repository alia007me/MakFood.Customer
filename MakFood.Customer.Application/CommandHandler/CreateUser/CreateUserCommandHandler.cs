using Contracts;
using MakFood.Customer.Domain.Interfaces;
using MakFood.Customer.Domain.Models.Entities.User;
using MakFood.Customer.Infrstructure.DataAccess.Context;
using MassTransit;
using MediatR;

namespace MakFood.Customer.Application.CommandHandler.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly ApplicationDbContext _context;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(ApplicationDbContext context, IPublishEndpoint publishEndpoint, IUserRepository userRepository)
        {
            _context = context;
            _publishEndpoint = publishEndpoint;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await RegisterUser(request.PhoneNumber);
            var identity = new IdentityInformation(request.FirstName, request.LastName);
            var account = new AccountInformation();
            var contact = new ContactInformation(request.PhoneNumber);

            var user = new User(identity, account, contact);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            await _publishEndpoint.Publish(new UserCreated
            {
                UserId = user.Id,
                UserName = $"{request.UserName}",
                Password = request.Password,
                PhoneNumber = request.PhoneNumber
            });

            return user.Id;
        }


        private async Task RegisterUser(string phoneNumber)
        {
           var result = await _userRepository.IsUserExistByPhoneNumber(phoneNumber);
            if (result) throw new Exception("this phoneNumber Is already registerd");

        }
    }
    }








//using MakFood.Customer.Application.Servises;
//using MakFood.Customer.Domain.Interfaces;
//using MakFood.Customer.Domain.Models.Entities.User;
//using MakFood.Customer.Infrstructure.DataAccess.Context;
//using MediatR;
//using Microsoft.AspNetCore.Http.HttpResults;


//namespace MakFood.Customer.Application.CommandHandler.CreateUser
//{
//    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,Guid>
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly IUserRepository _userRepository;

//        public CreateUserCommandHandler(ApplicationDbContext context, IUserRepository userRepository)
//        {
//            _context = context;
//            _userRepository = userRepository;
//        }

//        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
//        {
//            await RegisterUser(request.PhoneNumber);  

//            var accountInfo = new AccountInformation();
//            var contactInfo = new ContactInformation(request.PhoneNumber);
//            var identityInfo = new IdentityInformation(request.FirstName, request.LastName);

//            var user = new User(identityInfo,accountInfo,contactInfo);
//            _context.Add<User>(user);
//            await _context.SaveChangesAsync();

//            return user.Id;
//        }


//        private async Task RegisterUser(string phoneNumber)
//        {
//            var result = await _userRepository.IsUserExistByPhoneNumber(phoneNumber);
//            if (result) throw new Exception("this phoneNumber Is already registerd");

//        }
//    }
//}
