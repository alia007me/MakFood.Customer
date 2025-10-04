

using MakFood.Customer.Application.Dtos;
using MakFood.Customer.Domain.Models.Entities.User;

namespace MakFood.Customer.Application.Servises
{
    public interface IUserServiceRepository
    {
        public Task RegisterUser(string phoneNumber);
    }
}
