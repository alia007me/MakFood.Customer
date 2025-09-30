using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MakFood.Customer.Domain.Models.Entities.User
{
    /// <summary>
    /// این کلاس اطلاعات مربوط به آدرس(های) کاربر را ذخیره می کند
    /// </summary>
    /// <remarks>
    /// شامل مقادیر تایتل، آدرس خیابان، شماره پلاک، شماره واحد و کد پستی می باشد
    /// همچنین دارای سه متد صحت سنجی برای ورودی های تایتل، آدرس خیابان و کد پستی می باشد
    /// </remarks>
    public class Address
    {
        /// <summary>
        /// این کانستراکتور مقادیر حیاتی و مهم مربوط به کلاس را دریافت می کند
        /// </summary>
        /// <param name="title">نام نمایشی و کوتاه برای آدرس</param>
        /// <param name="streetAddres">آدرس خیابان</param>
        /// <param name="houseNumber">شماره پلاک</param>
        /// <param name="unitNo">شماره واحد</param>
        /// <param name="postalCode">کد پستی</param>
        public Address(string title, string streetAddres, uint houseNumber, uint unitNo, string postalCode)
        {
            Id = Guid.NewGuid();

            ValidityCheckTitle(title);
            ValidityCheckStreetAddress(streetAddres);
            ValidityPostalCode(postalCode);


            this.Title = title;
            this.StreetAddres = streetAddres;
            this.HouseNumber = houseNumber;
            this.UnitNo = unitNo;
            this.PostalCode = postalCode;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string StreetAddres { get; set; }
        public uint HouseNumber { get; set; }
        public uint UnitNo { get; set; }
        public string PostalCode { get; set; }


        /// <summary>
        /// این متد ورودی تایتل را صحت سنجی می کند
        /// </summary>
        /// <param name="title">ورودی تایتل نمایشی برای تمایز آدرس ها می باشد</param>
        /// <exception cref="Exception">مقدار نباید نال، خالی، یا شامل نمادها باشد</exception>
        public void ValidityCheckTitle(string title)
        {
            if (title == null) throw new Exception("Your title can't be null");
            string titleRegex = "([a-zA-Z0-9 \\s]+)";
            if (!Regex.IsMatch(title, titleRegex)) throw new Exception("You can only use A-Z a-z and space.");
        }

        /// <summary>
        /// این متد ورودی آدرس خیابان را صحت سنجی می کند
        /// </summary>
        /// <param name="street">آدرس خیابان شامل بخش هایی مانند، نام محله، میدان و... می باشد</param>
        /// <exception cref="Exception">نباید نال، خالی یا شامل نمادهایی بجز کاراکتر های جدا کننده باشد</exception>
        public void ValidityCheckStreetAddress(string street)
        {
            if (street == null) throw new Exception("Your title can't be null");
            string streetAddressRegex = "([a-zA-Z0-9,،._\\s]+)";
            if (!Regex.IsMatch(street, streetAddressRegex)) throw new Exception("You can only use A-Z a-z ,space ,_.، ");
        }

        /// <summary>
        /// این متد ورودی کد پستی را برسی می کند
        /// </summary>
        /// <param name="postalCode">کد پستی تنها شامل عدد است</param>
        /// <exception cref="Exception">نباید نال، خالی، یا شامل چیزی بجز عدد باشد</exception>
        public void ValidityPostalCode(string postalCode)
        {
            if (postalCode == null) throw new Exception("Your PostalCode can't be null");
            string postalcodeRegex = @"^\d{10}$";
            if (!Regex.IsMatch(postalCode, postalcodeRegex)) throw new Exception("you can only use 0-9");
        }
    }
}
