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
    /// اطلاعات هویتی شامل نام و نام خانوادگی و تاریخ تولد می باشد و دو متد جهت صحت سنجی نام و تاریخ تولد وجود دارد
    /// </remarks>
    public class IdentityInformation
    {
        /// <summary>
        /// این کانستراکتور نام و نام خانوادگی را دریافت کرده و پس از صحت سنجی ثبت می کند
        /// </summary>
        /// <param name="firstName">نام</param>
        /// <param name="lastName">نام خانوادگی</param>
        public IdentityInformation(string firstName, string lastName)
        {
            this.id = Guid.NewGuid();

            ValidityCheckName(firstName);
            ValidityCheckName(lastName);

            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateOnly? birthDate { get; set; }

        /// <summary>
        /// این متد نام و نام خانوادگی را صحت سنجی می کند
        /// </summary>
        /// <param name="name">نام و یا نام خانوادگی</param>
        /// <exception cref="Exception">نام نمیتواند نال، خالی و یا شامل کاراکتر های مختلف باشد</exception>
        public void ValidityCheckName(string name)
        {
            string NameRegex = "([a-zA-Z0-9 \\s]+)";
            if (!Regex.IsMatch(name, NameRegex)) throw new Exception("You can only use A-Z a-z and space.");

        }

        /// <summary>
        /// این متد تاریخ تولد را برسی می کند
        /// </summary>
        /// <param name="birthDate">تاریخ تولد</param>
        /// <exception cref="Exception">تاریخ تولد نمی تواند نال، خالی،بیشتر از 150 سال قبل و یا در آینده باشد </exception>
        public void ValidityCheckBirthDate(DateOnly birthDate)
        {
            DateOnly max = birthDate.AddYears(-150);
            if (birthDate >= DateOnly.FromDateTime(DateTime.Now) || birthDate <= max) throw new Exception("please enter valid birthDate");

        }

        /// <summary>
        /// این متد تاریخ تولد را ثبت می کند و یا اگر وجود داشت تغییر می دهد
        /// </summary>
        /// <param name="BirthDate">تاریخ تولد</param>
        /// <remarks>
        /// ابتدا تاریخ را برسی و صحت سنجی می کند و پس از آن، آن را قرار می دهد
        /// </remarks>
        public void AddReplaceBirthDate(DateOnly BirthDate)
        {
            ValidityCheckBirthDate(BirthDate);
            birthDate = BirthDate;
        }
    }
}
