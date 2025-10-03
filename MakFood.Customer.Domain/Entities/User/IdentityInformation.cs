using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MakFood.Customer.Domain.Models.Entities.User
{
    /// <summary>
    /// این کلاس اطلاعات هویتی مربوط به کاربر را ذخیره می کند
    /// </summary>
    /// <remarks>
    /// اطلاعات هویتی شامل نام و نام خانوادگی و تاریخ تولد می باشد
    /// متد هایی جهت صحبت سنجی، آپدیت و دیلیت می باشد
    /// </remarks>
    public class IdentityInformation
    {
        private IdentityInformation() { }

        /// <summary>
        /// این کانستراکتور نام و نام خانوادگی را دریافت کرده و پس از صحت سنجی ثبت می کند
        /// </summary>
        /// <param name="firstName">نام</param>
        /// <param name="lastName">نام خانوادگی</param>
        public IdentityInformation(string firstName, string lastName)
        {
            this.Id = Guid.NewGuid();

            ValidityCheckName(firstName);
            ValidityCheckName(lastName);
            
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Guid Id { get; private init; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly? BirthDate { get; private set; }

        /// <summary>
        /// این متد نام و نام خانوادگی را صحت سنجی می کند
        /// </summary>
        /// <param name="name">نام و یا نام خانوادگی</param>
        /// <exception cref="Exception">نام نمیتواند نال، خالی و یا شامل کاراکتر های مختلف باشد</exception>
        private void ValidityCheckName(string name)
        {
            string nameRegex = "([a-zA-Z0-9 \\s]+)";
            if (!Regex.IsMatch(name, nameRegex)) throw new Exception("You can only use A-Z a-z and space.");

        }

        /// <summary>
        /// این متد تاریخ تولد را برسی می کند
        /// </summary>
        /// <param name="birthDate">تاریخ تولد</param>
        /// <exception cref="Exception">تاریخ تولد نمی تواند نال، خالی،بیشتر از 150 سال قبل و یا در آینده باشد </exception>
        private void ValidityCheckBirthDate(DateOnly birthDate)
        {
            DateOnly max = birthDate.AddYears(-150);
            if (birthDate >= DateOnly.FromDateTime(DateTime.Now) || birthDate <= max) throw new Exception("please enter valid birthDate");

        }

        /// <summary>
        /// این متد تاریخ تولد را ثبت می کند و یا اگر وجود داشت تغییر می دهد
        /// </summary>
        /// <param name="birthDate">تاریخ تولد</param>
        /// <remarks>
        /// ابتدا تاریخ را برسی و صحت سنجی می کند و پس از آن، آن را قرار می دهد
        /// </remarks>
        public void AddReplaceBirthDate(DateOnly birthDate)
        {
            ValidityCheckBirthDate(birthDate);
            BirthDate = birthDate;
        }

        /// <summary>
        /// نام را آپدیت می کند
        /// </summary>
        /// <param name="firstName"></param>
        public void UpdateFirstName(string firstName)
        {
            ValidityCheckName(firstName);
            FirstName = firstName;
        }

        /// <summary>
        /// نام خانوادگی را آپدیت می کند
        /// </summary>
        /// <param name="lastName"></param>
        public void UpdateLastName(string lastName)
        {
            ValidityCheckName(lastName);
            LastName = lastName;
        }

        /// <summary>
        /// تاریخ تولد را حذف می کند
        /// </summary>
        public void DeleteBirthDate()
        {
            BirthDate = null;
        }

    }
}
