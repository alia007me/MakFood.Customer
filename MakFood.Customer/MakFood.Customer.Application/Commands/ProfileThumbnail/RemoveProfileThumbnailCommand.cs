using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Application.Commands.ProfileThumbnail
{
    public record RemoveProfileThumbnailCommand : IRequest<ProfileThumbnailcommandResponse>
    {
        public Guid UserId { get; set; }
    }
}
