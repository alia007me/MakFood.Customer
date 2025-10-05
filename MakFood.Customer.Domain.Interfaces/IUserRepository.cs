using MakFood.Customer.Domain.Models.Entities.User;

namespace MakFood.Customer.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        void UpdateUser(User user);
        Task<User> GetUserById(Guid id);  
        Task<User> GetUserByPhoneNumber(string phoneNumber);
        Task<bool> IsUserExistByPhoneNumber(string phoneNumber);
        
    }
}
