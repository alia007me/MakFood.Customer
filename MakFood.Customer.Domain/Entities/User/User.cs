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
            id = Guid.NewGuid();
            this.identity = identity;
            this.account = account;
            this.contactinfo = contactinfo;
        }

        public Guid id { get; set; }
        public IdentityInformation identity { get; set; }
        public AccountInformation account { get; set; }
        public ContactInformation contactinfo { get; set; }
        public List<Address>? addresses { get; set; }


        /// <summary>
        /// متد برای اضافه کردن آدرس به لیست آدرس
        /// </summary>
        /// <param name="address"></param>
        public void AddAddres(Address address)
        {
            addresses.Add(address);
        }
    }
}
