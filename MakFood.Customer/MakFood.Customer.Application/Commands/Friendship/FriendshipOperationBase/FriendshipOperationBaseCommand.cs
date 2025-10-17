using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Application.Commands.Friendship.FriendshipOperationBase
{
    public abstract class FriendshipOperationBaseCommand : IRequest
    {
        public Guid FriendshipId { get; set; }
        public Guid UserId { get; set; }
    }
}
