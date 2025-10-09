namespace MakFood.Customer.Domain.FriendshipAggregate.Contracts
{
    public interface IFriendshipRepository
    {
        /// <summary>
        /// دریافت دوستی با استفاده از شناسه دوستی
        /// </summary>
        /// <param name="id">شناسه دوستی</param>
        /// <param name="ct">توکن کنسل کردن عملیات</param>
        /// <returns>اطلاعات دوستی</returns>
        public Task<Friendship?> GetFriendshipById(Guid id, CancellationToken ct);

        /// <summary>
        /// دریافت لیست درخواست های دوستی ارسال شده با استفاده از شناسه کاربر
        /// </summary>
        /// <param name="recieverId">شناسه کاربر</param>
        /// <param name="ct">توکن کنسل کردن عملیات</param>
        /// <returns>لیست درخواست های دوستی</returns>
        public Task<List<Friendship>> GetFriendshipRequests(Guid recieverId, CancellationToken ct);

        /// <summary>
        /// دریافت لیست دوستی ها با استفاده از شناسه کاربر
        /// </summary>
        /// <param name="userId">شناسه کاربر</param>
        /// <param name="ct">توکن کنسل کردن عملیات</param>
        /// <returns>لیست دوستی ها</returns>
        public Task<List<Friendship>> GetAllFriendships(Guid userId, CancellationToken ct);

        /// <summary>
        /// اضافه کردن دوستی
        /// </summary>
        /// <param name="friendship">اطلاعات دوستی</param>
        public void AddFriendship(Friendship friendship);
    }
}
