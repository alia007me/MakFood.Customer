using FluentValidation;

namespace MakFood.Customer.Application.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId can not be null");
        }
    }
}

