using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Application.Commands.ProfileThumnail
{
    public record SetOrUpdateProfileThumnailcommad : IRequest<ProfileThumnailcommandResponse>
    {
        public Guid Id { get; set; }
        public string ProfileThumnail {  get; set; }
    }
}
