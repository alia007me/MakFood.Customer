using MakFood.Customer.Application.Servises;
using MakFood.Customer.Infrstructure.DataAccess.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Application.CommandHandler.CreateUser
{
    public class CreateAddresCommandHandler : IRequestHandler<CreateAddresCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserServiceRepository _userService;

        public CreateAddresCommandHandler(ApplicationDbContext context, IUserServiceRepository userService)
        {
            _context = context;
            _userService = userService;
        }

        public Task Handle(CreateAddresCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        

    }
}
