using MakFood.Customer.Domain.Interfaces;
using MakFood.Customer.Domain.Models.Entities.User;
using MakFood.Customer.Infrstructure.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace MakFood.Customer.Infrstructure.DataAccess.Repository.DomainRepositories
{


    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User?> GetUserById(Guid id)
        {
            var target = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return target;
        }



        public async Task<User> GetUserByPhoneNumber(string phoneNumber)
        {
            var target = await _context.Users.FirstOrDefaultAsync(x => x.Contactinfo.PhoneNumber == phoneNumber);
            if (target == null) throw new Exception("The member you are looking for probebly dosent exist.");
            return target;
        }

        public async Task<bool> IsUserExistByPhoneNumber(string phoneNumber)
        {
            var target = await _context.Users.FirstOrDefaultAsync(x => x.Contactinfo.PhoneNumber == phoneNumber);
            if (target == null) return false;
            else return true;

        }

      

        public async Task RemoveAddres(Guid UserId, Address address)
        {
            var target = await GetUserById(UserId);
            target.DeleteAddres(address);

        }

        public async Task AddAddress(Guid UserId, Address address)
        {
            var target = await GetUserById(UserId);
            target.DeleteAddres(address);
        }

        public async Task<User> GetUserwithAllAddressByUserId(Guid UserId)
        {
            return await _context.Users.Include(P => P.Addresses).SingleOrDefaultAsync(x=>x.Id == UserId);
        }

        public async void UpdateAddres(Guid user, Address address)
        {
            var target = await GetUserwithAllAddressByUserId(user);
            var addresslist = target.Addresses;

            var Forchange = addresslist.SingleOrDefault(j => j.Id == address.Id);

            Forchange = address;
        }
    }
} 
