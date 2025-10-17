using FluentValidation;

namespace MakFood.Customer.Application.Commands.Friendship.FriendshipOperationBase
{
    public abstract class FriendshipOperationBaseCommandValidation : AbstractValidator<FriendshipOperationBaseCommand>
    {
        public FriendshipOperationBaseCommandValidation()
        {
            RuleFor(x => x.FriendshipId).NotEmpty().WithMessage("FriendshipId can not be empty").NotNull().WithMessage("FriendshipId can not be null");
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId can not be empty").NotNull().WithMessage("UserId can not be null");
        }
    }
}
