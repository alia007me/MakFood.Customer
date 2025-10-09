using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MakFood.Customer.Domain.Models.Entities.User
{
    /// <summary>
    /// این کلاس اطلاعات ارتباطی مربوط به کاربر را ذخیره می کند
    /// </summary>
    /// <remarks>
    /// این کلاس شامل شامل ایمیل و شماره تلفن می باشد
    /// دارای متد های ولیدیشن برای این دو و آپدیت شماره تلفن و ایمیل، و حذف ایمیل می باشد
    /// </remarks>
    public class ContactInformation
    {
        private ContactInformation() { }
        /// <summary>
        /// این کانستراکتور فقط شماره تلفن را به عنوان مورد ضروری از کاربر دریافت می کند
        /// </summary>
        /// <param name="phoneNumber">شماره تلفن کاربر</param>
        public ContactInformation(string phoneNumber)
        {
            Id = Guid.NewGuid();
            ValidityCheckphoneNumber(phoneNumber);

            this.PhoneNumber = phoneNumber;
        }
        public Guid Id { get; private init; }
        public string PhoneNumber { get; private set; }
        public string? Email { get; private set; }

        /// <summary>
        /// این متد شماره تلفن را صحت سنجی می کند
        /// </summary>
        /// <param name="phoneNumber">شماره تلفن</param>
        /// <exception cref="Exception">شماره تلفن نباید نال، خالی، و خارج از قالب شماره تلفن در ایران باشد</exception>
        private void ValidityCheckphoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) throw new Exception("Phone Number is Empty or Null");

            var reg = @"^(\+98|0)\d{10}$";
            if (!Regex.IsMatch(phoneNumber, reg)) throw new Exception("pls enter the valid phone number");

        }

        /// <summary>
        /// این متد ایمیل را صحت سنجی می کند
        /// </summary>
        /// <param name="email">ایمیل</param>
        /// <exception cref="Exception">ایمیل نباید نال، خالی، و خارج از قالب ایمیل باشد</exception>
        private void ValidityCheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new Exception("Email is empty or null");

            var reg = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; ;
            if (!Regex.IsMatch(email, reg)) throw new Exception("pls enter the valid Email");

        }

        /// <summary>
        /// ایمیل را در صورت وجود آپدیت و در صورت وجود نداشتن پر می کند
        /// </summary>
        /// <param name="email">ایمیل</param>
        public void SetUpdateEmail(string email)
        {

            ValidityCheckEmail(email);
            Email = email;
        }

        /// <summary>
        /// شماره تلفن را آپدیت می کند
        /// </summary>
        /// <param name="phoneNumber">شماره تلفن</param>
        public void UpdatePhoneNumber(string phoneNumber)
        {
            ValidityCheckphoneNumber(phoneNumber);
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// ایمیل را حذف می کند
        /// </summary>
        public void DeleteEmail()
        {
            Email = null;
        }
    }
}
