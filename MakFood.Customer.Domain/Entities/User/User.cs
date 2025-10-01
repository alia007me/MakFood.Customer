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
    /// شامل دو متد برای اضافه کردن و پاک کردن آدرس یوزر می باشد
    /// </remarks>
    public class User
    {
        private List<Address> _address;

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

        public Guid Id { get;private init; }
        public IdentityInformation Identity { get; set; }
        public AccountInformation Account { get; set; }
        public ContactInformation Contactinfo { get; set; }
        public IReadOnlyList<Address>? Addresses { get => _address.AsReadOnly(); }


        /// <summary>
        /// متد برای اضافه کردن آدرس به لیست آدرس
        /// </summary>
        /// <param name="address"></param>
        public void AddAddres(Address address)
        {
            if (Addresses == null) throw new Exception("Address can't be Null");

            _address.Add(address);
        }

        /// <summary>
        /// آدرس را حذف می کند
        /// </summary>
        /// <param name="address"></param>
        /// <exception cref="Exception"></exception>
        public void DeleteAddres(Address address)
        {
            if (Addresses == null) throw new Exception("Address can't be Null");

            _address.Remove(address);
        }
    }
}
