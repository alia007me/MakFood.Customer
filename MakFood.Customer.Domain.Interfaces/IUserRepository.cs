using MakFood.Customer.Domain.Models.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MakFood.Customer.Domain.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// دریافت یک کاربر بر اساس شناسه
        /// </summary>
        Task<User?> GetByIdAsync(Guid userId);

        /// <summary>
        /// دریافت لیست تمام کاربران
        /// </summary>
        Task<IEnumerable<User>> GetAllAsync();

        /// <summary>
        /// افزودن یک کاربر جدید
        /// </summary>
        Task AddAsync(User user);

        /// <summary>
        /// به‌روزرسانی اطلاعات کاربر
        /// </summary>
        void Update(User user);

        /// <summary>
        /// حذف یک کاربر
        /// </summary>
        void Delete(User user);

        
        /// <summary>
        /// پیدا کردن کاربر بر اساس شماره تلفن (مورد ضروری برای ورود یا بازیابی)
        /// </summary>
        Task<User?> GetByPhoneNumberAsync(string phoneNumber);

     
    }
}
