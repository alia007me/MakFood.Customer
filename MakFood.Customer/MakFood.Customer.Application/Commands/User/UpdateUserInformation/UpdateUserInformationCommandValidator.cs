using FluentValidation;

namespace MakFood.Customer.Application.Commands.User.UpdateUserInformation
{
    public class UpdateUserInformationCommandValidator : AbstractValidator<UpdateUserInformationCommand>
    {
        public UpdateUserInformationCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("User Id can not be empty").NotNull().WithMessage("User Id can not be null");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName can not be empty").NotNull().WithMessage("FirstName can not be null");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName can not be empty").NotNull().WithMessage("LastName can not be null");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("BirthDate can not be empty").NotNull().WithMessage("BirthDate can not be null");

        }
    }

}



