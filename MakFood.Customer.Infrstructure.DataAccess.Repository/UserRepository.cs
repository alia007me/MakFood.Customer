using MakFood.Customer.Domain.Interfaces;
using MakFood.Customer.Domain.Models.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Infrstructure.DataAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        
        private readonly List<User> _users = new List<User>();

               
        public Task<User?> GetByIdAsync(Guid userId)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            return Task.FromResult(user);
        }

        /// <summary>
        ///  دریافت همه کاربران
        /// </summary>
        public Task<IEnumerable<User>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<User>>(_users);
        }

        /// <summary>
        ///  افزودن کاربر
        /// </summary>
        public Task AddAsync(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }

        /// <summary>
        /// به‌روزرسانی اطلاعات کاربر.
        /// توجه: در این پیاده‌سازی حافظه-محور، تغییرات از قبل روی مرجع شیء اعمال شده‌اند.
        /// </summary>
        public void Update(User user)
        {
            Console.WriteLine($"[Repository] User with ID {user.Id} marked for update.");
        }


        /// <summary>
        /// حذف کاربر
        /// </summary>
        public void Delete(User user)
        {
            _users.Remove(user);
        }

        /// <summary>
        ///  دریافت بر اساس شماره تلفن
        /// </summary>
        public Task<User?> GetByPhoneNumberAsync(string phoneNumber)
        {
            var user = _users.FirstOrDefault(u => u.Contactinfo.PhoneNumber == phoneNumber);
            return Task.FromResult(user);
        }

        /// <summary>
        ///  ذخیره تغییرات  
        /// </summary>
        public Task SaveChangesAsync()
        {
            
            Console.WriteLine("Changes (simulated) saved successfully.");
            return Task.CompletedTask;
        }
    }
}
