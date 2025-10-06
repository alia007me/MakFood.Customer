using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Application.CommandHandler._ّFriendShipe
{
    public record FriendshipCommand(
       string Action,            
       Guid UserId,
       Guid OtherUserId,
       string? NickNameSender = null,
       string? NickNameReceiver = null,
       Guid? FriendshipId = null
   ) : IRequest<bool>;
}
