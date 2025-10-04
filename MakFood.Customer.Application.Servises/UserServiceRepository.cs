
using MakFood.Customer.Application.Dtos;
using MakFood.Customer.Domain.Interfaces;
using MakFood.Customer.Domain.Models.Entities.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace MakFood.Customer.Application.Servises
{
    public class UserServiceRepository : IUserServiceRepository
    {
        private IUserRepository _userRepository;

        public UserServiceRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task RegisterUser(string phoneNumber)
        {
            var result = await _userRepository.IsUserExistByPhoneNumber(phoneNumber);
            if (result) throw new Exception("this phoneNumber Is already registerd");
        }

        
    }
}
