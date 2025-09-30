using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Domain.Models.Entities.User
{
    /// <summary>
    /// این کلاس تمام اطلاعات کاربر را در خود قرار می دهد
    /// </summary>
    /// <remarks>
    /// شامل یک متد برای اضافه کردن آدرس می باشد
    /// </remarks>
    public class User
    {
        /// <summary>
        /// کانستراکتور اطلاعات مربوط به کاربر
        /// </summary>
        /// <param name="identity">هویتی</param>
        /// <param name="account">اکانت</param>
        /// <param name="contactinfo">ارتباطی</param>
        public User(IdentityInformation identity, AccountInformation account, ContactInformation contactinfo)
        {
            Id = Guid.NewGuid();
            this.Identity = identity;
            this.Account = account;
            this.Contactinfo = contactinfo;
        }

        public Guid Id { get; set; }
        public IdentityInformation Identity { get; set; }
        public AccountInformation Account { get; set; }
        public ContactInformation Contactinfo { get; set; }
        public List<Address>? Addresses { get; set; }


        /// <summary>
        /// متد برای اضافه کردن آدرس به لیست آدرس
        /// </summary>
        /// <param name="address"></param>
        public void AddAddres(Address address)
        {
            Addresses.Add(address);
        }
    }
}
