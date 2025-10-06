using MakFood.Customer.Domain.Interfaces;
using MakFood.Customer.Domain.Models.Entities.Enums;
using MakFood.Customer.Domain.Models.Entities.Friendship;
using MakFood.Customer.Infrstructure.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakFood.Customer.Infrstructure.DataAccess.Repository.DomainRepositories
{
    /// <summary>
    /// ریپازیتوری مسئول انجام عملیات داده‌ای مربوط به موجودیت <see cref="Friendship"/>.
    /// شامل متدهایی برای افزودن، واکشی، و به‌روزرسانی وضعیت دوستی بین کاربران.
    /// </summary>
    public class FriendshipRepository : IFriendshipRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// سازنده‌ی کلاس <see cref="FriendshipRepository"/>.
        /// </summary>
        /// <param name="context">کانتکست EF Core که دسترسی به دیتابیس را فراهم می‌کند.</param>
        public FriendshipRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// افزودن یک رابطه‌ی دوستی جدید (درخواست دوستی) به دیتابیس.
        /// </summary>
        /// <param name="friendship">موجودیت دوستی جدید.</param>
        public async Task AddAsync(Friendship friendship)
        {
            await _context.Set<Friendship>().AddAsync(friendship);
        }

        /// <summary>
        /// واکشی موجودیت دوستی بر اساس شناسه‌ی منحصربه‌فرد آن.
        /// </summary>
        /// <param name="friendshipId">شناسه‌ی دوستی.</param>
        /// <returns>موجودیت <see cref="Friendship"/> در صورت یافت شدن.</returns>
        /// <exception cref="Exception">اگر دوستی با شناسه‌ی مشخص پیدا نشود.</exception>
        public async Task<Friendship> GetByIdAsync(Guid friendshipId)
        {
            var friendship = await _context.Set<Friendship>()
                .FirstOrDefaultAsync(f => f.Id == friendshipId);

            if (friendship == null)
                throw new Exception($"دوستی با شناسه {friendshipId} یافت نشد.");

            return friendship;
        }

        /// <summary>
        /// به‌روزرسانی وضعیت موجودیت دوستی (مثلاً هنگام پذیرش، رد یا لغو).
        /// </summary>
        /// <param name="friendship">موجودیت دوستی که باید به‌روزرسانی شود.</param>
        public void Update(Friendship friendship)
        {
            _context.Set<Friendship>().Update(friendship);
        }

        /// <summary>
        /// واکشی تمام دوستی‌های "برقرارشده" (Accepted) که کاربر در آن‌ها نقش دارد.
        /// شامل روابطی است که کاربر یا درخواست‌دهنده بوده یا پذیرنده.
        /// </summary>
        /// <param name="userId">شناسه‌ی کاربر جاری.</param>
        /// <returns>لیستی از روابط دوستی پذیرفته‌شده.</returns>
        public async Task<IEnumerable<Friendship>> GetEstablishedFriendshipsAsync(Guid userId)
        {
            return await _context.Set<Friendship>()
                .Where(f =>
                    f.MatchingState == MatchingState.Accepted &&
                    (f.UserId == userId || f.OtherUserId == userId))
                .AsNoTracking()
                .ToListAsync();
        }

        /// <summary>
        /// واکشی تمام درخواست‌های دوستی در وضعیت "در انتظار" (Requested)
        /// که کاربر جاری گیرنده‌ی آن‌ها است.
        /// </summary>
        /// <param name="userId">شناسه‌ی کاربر جاری.</param>
        /// <returns>لیستی از درخواست‌های دوستی دریافتی در وضعیت در انتظار.</returns>
        public async Task<IEnumerable<Friendship>> GetIncomingPendingRequestsAsync(Guid userId)
        {
            return await _context.Set<Friendship>()
                .Where(f =>
                    f.MatchingState == MatchingState.Requested &&
                    f.OtherUserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
