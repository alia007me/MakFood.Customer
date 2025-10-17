using MediatR;

namespace MakFood.Customer.Application.Commands.User.UpdateUserInformation
{

    public class UpdateUserInformationCommand : IRequest<UpdateUserInformationCommandRespone>
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
    }

}



