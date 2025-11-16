using MakFood.Customer.Domain.UserAggregate.Contracts;
using MediatR;

namespace MakFood.Customer.Application.Commands.Login
{
    internal sealed class LoginCommandHandler : IRequestHandler<LoginCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;

        public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<string> Handle(LoginCommand request, CancellationToken ct)
        {

            var targerUser = await _userRepository.GetUserByPhoneNumber(request.phonenumber,ct);

            if (targerUser is null) throw new NotFoundException();

            if (targerUser.IdentityInformation.FirstName != request.FirstName) throw new NotMatchException();

            string token = _jwtProvider.Generate(targerUser);

            return token;

        }
        #region exceptions

        [Serializable]
        private class NotFoundException : Exception
        {
            public NotFoundException()
            {
            }

            public NotFoundException(string? message) : base(message)
            {
            }

            public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
            {
            }
            
        }

        [Serializable]
        private class NotMatchException : Exception
        {
            public NotMatchException()
            {
            }

            public NotMatchException(string? message) : base(message)
            {
            }

            public NotMatchException(string? message, Exception? innerException) : base(message, innerException)
            {
            }
        }
        #endregion
    }
}
