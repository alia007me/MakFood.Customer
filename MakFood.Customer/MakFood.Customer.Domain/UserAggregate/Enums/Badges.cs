using System.ComponentModel;

namespace MakFood.Customer.Domain.UserAggregate.Enums
{
    public enum Badges
    {
        [Description("کاربر عادی")]
        Normal = 1,
        [Description("کاربر برنزی")]
        Bronze = 2,
        [Description("کاربر نقره ای")]
        Silver = 3,
        [Description("کاربر طلایی")]
        Gold = 4,
        [Description("کاربر الماسی")]
        Diamond = 5
    }
}