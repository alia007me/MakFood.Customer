using FluentValidation;

namespace MakFood.Customer.Application.CommandHandler.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("User Id is required");
        }
    }
}
