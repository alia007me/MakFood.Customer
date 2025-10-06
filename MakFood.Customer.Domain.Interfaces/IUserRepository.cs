using MakFood.Customer.Domain.Models.Entities.User;

namespace MakFood.Customer.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task AddUser(User user);
        void UpdateUser(User user);
        Task<User> GetUserById(Guid id);  
        void UpdateAddres(Guid user, Address address);
        Task<User> GetUserByPhoneNumber(string phoneNumber);
        Task<bool> IsUserExistByPhoneNumber(string phoneNumber);
        Task<User> GetUserwithAllAddressByUserId(Guid UserId);
        Task RemoveAddres(Guid UserId, Address address);
        Task AddAddress(Guid UserId, Address address);
        
        
    }
}
