using FluentValidation;

namespace MakFood.Customer.Application.Commands.User.RemoveUserAddress
{
    public class RemoveUserAddressCommandValidator : AbstractValidator<RemoveUserAddressCommand>
    {
        public RemoveUserAddressCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId can not be empty or null");
            RuleFor(x => x.AddressId).NotEmpty().WithMessage("AddressId can not be empty or null");
        }
    }
}
