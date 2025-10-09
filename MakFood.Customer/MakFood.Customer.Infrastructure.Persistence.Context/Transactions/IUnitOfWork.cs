namespace MakFood.Customer.Infrastructure.Persistence.Context.Transactions
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// ذخیره تغییرات
        /// </summary>
        /// <param name="ct">توکن کنسل کردن عملیات</param>
        /// <returns></returns>
        public Task<int> Commit(CancellationToken ct);
    }
}
