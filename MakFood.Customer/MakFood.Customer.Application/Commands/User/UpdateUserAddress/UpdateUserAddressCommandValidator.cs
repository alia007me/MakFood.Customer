using FluentValidation;

namespace MakFood.Customer.Application.Commands.User.UpdateUserAddress
{
    public class UpdateUserAddressCommandValidator : AbstractValidator<UpdateUserAddressCommand>
    {
        public UpdateUserAddressCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId can not be null");
            RuleFor(x => x.AddressId).NotEmpty().WithMessage("AddressId can not be null");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Address Title can not be null");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Address Street can not be null");
            RuleFor(x => x.Plaque).NotEmpty().WithMessage("Address Plaque can not be null");
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Address PostalCode can not be null");
        }
    }
}
