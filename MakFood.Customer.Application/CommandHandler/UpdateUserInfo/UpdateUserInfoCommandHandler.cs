using MakFood.Customer.Domain.Interfaces;
using MakFood.Customer.Domain.Models.Entities.User;
using MakFood.Customer.Infrstructure.DataAccess.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Application.CommandHandler.UpdateUserInfo
{
    public class UpdateUserInfoCommandHandler : IRequestHandler<UpdateUserInfoCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserInfoCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        

        public async Task<string> Handle(UpdateUserInfoCommand command, CancellationToken cancellationToken)
        {
            var target = await _userRepository.GetUserById(command.Id);

            if (target == null) throw new Exception("your member dose not exist");

            if (!string.IsNullOrEmpty(command.FirstName)) target.Identity.UpdateFirstName(command.FirstName);

            if (!string.IsNullOrEmpty(command.LastName)) target.Identity.UpdateLastName(command.LastName);

            if (command.AddresId != null)
            {
                if (await IsThisAddresBlongsToThisUser(command.Id, command.AddresId))
                {
                    var targetaddres = await ReturnAddress(command.Id, command.AddresId);

                    if (!string.IsNullOrEmpty(command.AddresTitle)) targetaddres.UpdateTitle(command.AddresTitle);

                    if (!string.IsNullOrEmpty(command.StreetAddres)) targetaddres.UpdateStreetAddres(command.StreetAddres);

                    if(command.HouseNumber != null) targetaddres.UpdateHouseNumber(command.HouseNumber);

                    if(command.UnitNo != null) targetaddres.UpdateUnitNo(command.UnitNo);

                    if (!string.IsNullOrEmpty(command.PostalCode)) targetaddres.UpdatePostalCode(command.PostalCode);

                    _userRepository.UpdateAddres(command.Id, targetaddres);


                } else throw new Exception("this addres is not exist or not for your account");
                
                
            }
            
            _unitOfWork.Users.UpdateUser(target);

            await _unitOfWork.SaveChange(cancellationToken);

            return "Information updated!";
        }

        private async Task<bool> IsThisAddresBlongsToThisUser(Guid UserId, Guid? AddresId)
        {
            var target = await _userRepository.GetUserwithAllAddressByUserId(UserId);
            var addresslist = target._address;
            
            if(addresslist.SingleOrDefault(j => j.Id == AddresId) != null) return true;
            else return false;
        }

        private async Task<Address> ReturnAddress(Guid UserId, Guid? AddresId)
        {
            var target = await _userRepository.GetUserwithAllAddressByUserId(UserId);
            var addresslist = target._address;

            Console.WriteLine(addresslist);
            var result = addresslist.SingleOrDefault(j => j.Id == AddresId);
            

            if (result == null) throw new Exception("this addres Not found");

            return result;
           
        }
    }
}
