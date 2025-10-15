using FluentValidation;
namespace MakFood.Customer.Application.Commands.AddUserAddress
{
    public class AddAddressCommandValidator : AbstractValidator<AddUserAddressCommand>
    {
        public AddAddressCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId can not be null");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Address Title can not be null");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Address Street can not be null");
            RuleFor(x => x.Plaque).NotEmpty().WithMessage("Address Plaque can not be null");
            RuleFor(x => x.PostalCode).NotEmpty().WithMessage("Address PostalCode can not be null");
        }
    }
}


