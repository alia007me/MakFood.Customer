using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Domain.Interfaces
{
    /// <summary>
    /// قرارداد (Contract) برای الگوی Unit of Work.
    /// مسئولیت مدیریت تراکنش و ذخیره نهایی تغییرات در دیتابیس را بر عهده دارد.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// ذخیره تمام تغییرات انجام شده توسط تمام Repositoryهای ردیابی شده را به صورت ناهمگام در دیتابیس.
        /// </summary>
        Task SaveChangesAsync();
    }
}
