using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Application.Commands.ProfileThumbnail
{
    public record ProfileThumbnailcommandResponse
    {
        public Guid UserId { get; set; }
        public string? ProfileThumbnailPath { get; set; }
    }
}
