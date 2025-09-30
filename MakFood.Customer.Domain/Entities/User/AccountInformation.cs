using MakFood.Customer.Domain.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MakFood.Customer.Domain.Models.Entities.User
{
    /// <summary>
    /// این کلاس اطلاعات اکانت یک فرد را ذخیره می کند
    /// </summary>
    /// <remarks>
    /// شامل تاریخ ورود، آدرس عکس پروفایل، درجه می باشد،
    /// یک متد برای صحت سنجی آدرس عکس، دو متد برای افزایش و کاهش رتبه
    /// و دو متد هم برای مدیریت عکس پروفایل قرار دارد
    /// </remarks>
    public class AccountInformation
    {
        /// <summary>
        /// کانستراکتور بدون مقدار ورودی برای ثبت مقدایر اولیه
        /// </summary>
        /// <remarks>
        /// با توجه به منطق پروژه در این کانستراکتور مقدار ورودی گرفتن لازم نبود
        /// </remarks>
        public AccountInformation()
        {
            Id = Guid.NewGuid();
            JoinDate = DateOnly.FromDateTime(DateTime.Now);
            Badge = Badge.Normal;
        }

        public Guid Id { get; private init; }
        public DateOnly JoinDate { get; private set; }
        public string? ProfilePicture { get;private set; }
        public Badge Badge { get; private set; }


        /// <summary>
        /// این متد عکس پروفایل جدید برای کاربر ثبت می کند
        /// </summary>
        /// <param name="URL"></param>
        /// <remarks>
        /// در ابتدا صحت سنجی انجام می شود و پس از آن عکس جدید جای عکس قبلی را می گیرد
        /// </remarks>
        public void SetReplaceProfilePicture(string url)
        {
            ProfilePicture = url;
        }

        /// <summary>
        ///  این متد عکس پروفایل را به صورت کامل حذف می کند و عکس پروفایل خالی می ماند
        /// </summary>
        public void RemoveprofilePicture()
        {
            ProfilePicture = null;
        }





    }
}
