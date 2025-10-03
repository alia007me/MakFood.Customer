using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Aplication.Service.ServiceInterfaces
{
    public interface IUserService
    {
        /// <summary>
        /// تنظیم یا جایگزینی عکس پروفایل یک کاربر
        /// این متد هیچ مقداری برنمی‌گرداند (تنها خطا یا موفقیت را اعلام می‌کند).
        /// </summary>
        /// <param name="userId">شناسه یکتای کاربر</param>
        /// <param name="profilePictureUrl">آدرس (URL) عکس پروفایل جدید</param>
        Task SetUserProfilePictureAsync(Guid userId, string profilePictureUrl);

        /// <summary>
        /// حذف عکس پروفایل کاربر
        /// </summary>
        Task RemoveUserProfilePictureAsync(Guid userId);
    }
}
