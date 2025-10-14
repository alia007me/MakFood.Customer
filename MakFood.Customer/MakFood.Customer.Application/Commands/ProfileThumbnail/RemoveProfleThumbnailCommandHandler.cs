using MakFood.Customer.Domain.UserAggregate.Contracts;
using MakFood.Customer.Infrastructure.Persistence.Context.Transactions;
using MakFood.Customer.Infrastructure.Substructure.Exceptions;
using MakFood.Customer.Domain.UserAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Application.Commands.ProfileThumbnail
{
    public class RemoveProfleThumbnailCommandHandler :IRequestHandler<RemoveProfileThumbnailCommand,ProfileThumbnailcommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProfleThumbnailCommandHandler(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public async Task<ProfileThumbnailcommandResponse> Handle(RemoveProfileThumbnailCommand command , CancellationToken ct)
        {
            var user = await _userRepository.GetUserById(command.UserId, ct)
                ?? throw new ValidationFailedDomainException("User not Found!");

            user.AccountInformation.RemoveProfileThumbnail();
            await _unitOfWork.Commit(ct);

            return new ProfileThumbnailcommandResponse
            {
                UserId = user.Id,
                ProfileThumbnailPath = null
            };
        }
    }
}
