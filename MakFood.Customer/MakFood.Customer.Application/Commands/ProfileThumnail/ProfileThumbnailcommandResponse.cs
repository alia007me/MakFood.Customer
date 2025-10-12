using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Application.Commands.ProfileThumnail
{
    public record ProfileThumnailcommandResponse
    {
        public Guid UserId { get; set; }
        public string? ProfileThumbnailPath { get; set; }
    }
}
