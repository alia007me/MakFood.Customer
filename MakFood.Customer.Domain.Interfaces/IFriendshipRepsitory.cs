using MakFood.Customer.Domain.Models.Entities.Friendship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Domain.Interfaces
{

    /// <summary>
    /// قرارداد ریپازیتوری برای مدیریت موجودیت Friendship.
    /// </summary>
    public interface IFriendshipRepository
    {
        /// <summary>
        /// واکشی موجودیت کامل دوستی بر اساس شناسه.
        /// </summary>
        /// <param name="friendshipId">شناسه دوستی.</param>
        /// <returns>موجودیت Friendship.</returns>
        Task<Friendship> GetByIdAsync(Guid friendshipId);

        /// <summary>
        /// به‌روزرسانی موجودیت دوستی (تغییر وضعیت: قبول، رد، لغو).
        /// </summary>
        /// <param name="friendship">موجودیت دوستی جهت به‌روزرسانی.</param>
        void Update(Friendship friendship);

        /// <summary>
        /// واکشی تمام دوستی‌های برقرار شده (Established) که کاربر در آن دخیل است.
        /// </summary>
        /// <param name="userId">شناسه کاربر جاری.</param>
        /// <returns>لیستی از دوستی‌های برقرار شده.</returns>
        Task<IEnumerable<Friendship>> GetEstablishedFriendshipsAsync(Guid userId);

        /// <summary>
        /// واکشی درخواست‌های ورودی (Pending) که کاربر جاری گیرنده آن است.
        /// </summary>
        /// <param name="userId">شناسه کاربر جاری.</param>
        /// <returns>لیستی از درخواست‌های دوستی در انتظار.</returns>
        Task<IEnumerable<Friendship>> GetIncomingPendingRequestsAsync(Guid userId);

        /// <summary>
        /// افزودن یک موجودیت دوستی جدید (ایجاد درخواست).
        /// </summary>
        /// <param name="friendship">موجودیت دوستی جدید.</param>
        Task AddAsync(Friendship friendship);
    }
}
    