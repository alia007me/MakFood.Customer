using FluentValidation;


namespace MakFood.Customer.Application.Commands.Friendship.CreateFriendship
{
    public class CreateFriendshipCommandValidator : AbstractValidator<CreateFriendshipCommand>
    {
        public CreateFriendshipCommandValidator()
        {
            RuleFor(x => x.SenderId).NotEmpty().WithMessage("SenderId can not be empty").NotNull().WithMessage("SenderId can not be null");
            RuleFor(x => x.ReceiverPhoneNumber).NotEmpty().WithMessage("ReceiverPhoneNumber can not be empty").NotNull().WithMessage("ReceiverPhoneNumber can not be null");
        }
    }

    
}


