namespace MakFood.Customer.Domain.UserAggregate.Contracts
{
    public interface IUserRepository
    {
        /// <summary>
        /// دریافت اطلاعات کاربر با استفاده از شناسه کاربر
        /// </summary>
        /// <param name="userId">شناسه کاربر</param>
        /// <param name="ct">توکن کنسل کردن عملیات</param>
        /// <returns>اطلاعات کاربر</returns>
        public Task<UserAccount?> GetUserById(Guid userId, CancellationToken ct);

        /// <summary>
        /// اضافه کردن یک کاربر
        /// </summary>
        /// <param name="user">اطلاعات کاربر</param>
        public void AddUser(UserAccount user);
    }
}
