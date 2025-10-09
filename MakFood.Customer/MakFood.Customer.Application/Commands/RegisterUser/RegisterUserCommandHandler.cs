using MakFood.Customer.Domain.UserAggregate.Contracts;
using MakFood.Customer.Infrastructure.Persistence.Context.Transactions;
using MassTransit;
using MediatR;

namespace MakFood.Customer.Application.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPublishEndpoint _publishEndpoint;

        public RegisterUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IPublishEndpoint publishEndpoint)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommand command, CancellationToken ct)
        {
            var user = command.ToModel();

            _userRepository.AddUser(user);

            await _unitOfWork.Commit(ct);

            await _publishEndpoint.Publish<UserRegisteredMessage>(command.ToMessage());

            return new RegisterUserCommandResponse
            {
                UserId = user.Id
            };
        }
    }
}
