using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using MakFood.Customer.Domain.Models.Entities.User; 
namespace MakFood.Customer.Application.Service; 

/// <summary>
/// قرارداد (Contract) برای عملیات‌های تجاری (Business Logic) مربوط به موجودیت کاربر (User).
/// </summary>
public interface IUserService
{
    

    /// <summary>
    /// آدرس عکس پروفایل کاربر مشخص شده را به‌روزرسانی یا جایگزین می‌کند.
    /// </summary>
    /// <param name="userId">شناسه منحصر به فرد کاربر مورد نظر.</param>
    /// <param name="profilePictureUrl">آدرس (URL) جدید عکس پروفایل.</param>
    /// <returns>یک Task که نشان دهنده تکمیل عملیات ناهمگام است.</returns>
    Task SetUserProfilePictureAsync(Guid userId, string profilePictureUrl);

    /// <summary>
    /// عکس پروفایل کاربر مشخص شده را حذف می‌کند (آدرس URL آن را پاک می‌کند).
    /// </summary>
    /// <param name="userId">شناسه منحصر به فرد کاربر مورد نظر.</param>
    /// <returns>یک Task که نشان دهنده تکمیل عملیات ناهمگام است.</returns>
    Task RemoveUserProfilePictureAsync(Guid userId);

    

   
}