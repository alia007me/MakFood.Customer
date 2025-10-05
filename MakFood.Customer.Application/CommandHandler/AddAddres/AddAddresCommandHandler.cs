using MakFood.Customer.Domain.Interfaces;
using MakFood.Customer.Domain.Models.Entities.User;
using MakFood.Customer.Infrstructure.DataAccess.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Application.CommandHandler.AddAddres
{
    public class AddAddresCommandHandler : IRequestHandler<AddAddresCommand,Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddAddresCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(AddAddresCommand Command, CancellationToken cancellationToken)
        {
            var target = await _userRepository.GetUserById(Command.UserId);
            if (target == null) throw new Exception("user have not exist");

            Address Adres = new Address(Command.Title, Command.StreetAddres, Command.HouseNumber);

            if (target.Addresses.Contains<Address>(Adres)) throw new Exception("this Addres already exist");
            
            target.AddAddres(Adres);

            _unitOfWork.Users.UpdateUser(target);

            await _unitOfWork.SaveChange(cancellationToken);

            return Adres.Id;
        }

    }
}
