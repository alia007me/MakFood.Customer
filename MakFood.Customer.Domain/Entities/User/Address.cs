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
    /// و برای متد ها بعلاوه ولیدیشن ها، شامل آپدیت همه موارد بعلاوه دیلیت کردن موارد کد پستی و شماره واحد می باشد
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
        public Address(string title, string streetAddres, uint houseNumber)
        {
            Id = Guid.NewGuid();

            ValidityCheckTitle(title);
            ValidityCheckStreetAddress(streetAddres);

            this.Title = title;
            this.StreetAddres = streetAddres;
            this.HouseNumber = houseNumber;
            
        }

        public Guid Id { get; private init; }
        public string Title { get; private set; }
        public string StreetAddres { get; private set; }
        public uint HouseNumber { get;private set; }
        public uint? UnitNo { get;private set; }
        public string? PostalCode { get; private set; }


        /// <summary>
        /// این متد ورودی تایتل را صحت سنجی می کند
        /// </summary>
        /// <param name="title">ورودی تایتل نمایشی برای تمایز آدرس ها می باشد</param>
        /// <exception cref="Exception">مقدار نباید نال، خالی، یا شامل نمادها باشد</exception>
        private void ValidityCheckTitle(string title)
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
        private void ValidityCheckStreetAddress(string street)
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
        private void ValidityPostalCode(string postalCode)
        {
            if (postalCode == null) throw new Exception("Your PostalCode can't be null");
            string postalcodeRegex = @"^\d{10}$";
            if (!Regex.IsMatch(postalCode, postalcodeRegex)) throw new Exception("you can only use 0-9");
        }

        /// <summary>
        /// تایتل را آپدیت می کند
        /// </summary>
        /// <param name="title">نام نمایشی آدرس</param>
        public void UpdateTitle(string title)
        {
            ValidityCheckTitle(title);
            Title = title;
        }

        /// <summary>
        /// آدرس خیابان را آپدیت می کند
        /// </summary>
        /// <param name="streetAddres">آدرس خیابان</param>
        public void UpdateStreetAddres(string streetAddres)
        {
            ValidityCheckStreetAddress(streetAddres);
            StreetAddres = streetAddres;
        }

        /// <summary>
        /// شماره خانه (پلاک) را آپدیت می کند
        /// </summary>
        /// <param name="houseNumber">پلاک</param>
        public void UpdateHouseNumber(uint houseNumber)
        { 
            HouseNumber = houseNumber;
        }

        /// <summary>
        /// کد پستی را آپدیت می کند
        /// </summary>
        /// <param name="postalCode">آپدیت کد پستی</param>
        public void UpdatePostalCode(string postalCode)
        {
            ValidityPostalCode(postalCode);
            PostalCode = postalCode;
        }

        /// <summary>
        /// شماره واحد را آپدیت می کند
        /// </summary>
        /// <param name="unitNo">شماره واحد</param>
        /// <exception cref="Exception">نمیتواند نال باشد</exception>
        public void UpdateUnitNo(string unitNo)
        {
            if (unitNo == null) throw new Exception("input of update Unit cant be null");
            if (!uint.TryParse(unitNo, out uint value)) throw new Exception("please Enter Natural Number");

            UnitNo = uint.Parse(unitNo); 
        }

        /// <summary>
        /// کد پستی را حذف می کند
        /// </summary>
        public void DeletePostalCode()
        {
            PostalCode = null;
        }
        
        /// <summary>
        /// شماره واحد را حذف می کند
        /// </summary>
        public void DeleteUnitNo()
        {
            UnitNo = null;
        }
    }
}
