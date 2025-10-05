
using MakFood.Customer.Domain.Interfaces;
using MakFood.Customer.Domain.Models.Entities.User;
using MakFood.Customer.Infrstructure.DataAccess.Context;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;


namespace MakFood.Customer.Application.CommandHandler.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand,Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            await RegisterUser(request.PhoneNumber);  

            var accountInfo = new AccountInformation();
            var contactInfo = new ContactInformation(request.PhoneNumber);
            var identityInfo = new IdentityInformation(request.FirstName, request.LastName);

            var user = new User(identityInfo,accountInfo,contactInfo);
            await _unitOfWork.Users.AddUser(user);

            await _unitOfWork.SaveChange(cancellationToken);

            return user.Id;
        }


        private async Task RegisterUser(string phoneNumber)
        {
            var result = await _userRepository.IsUserExistByPhoneNumber(phoneNumber);
            if (result) throw new Exception("this phoneNumber Is already registerd");

        }
    }
}
