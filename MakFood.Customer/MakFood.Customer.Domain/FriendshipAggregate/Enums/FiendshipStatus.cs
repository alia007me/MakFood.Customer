using System.ComponentModel;

namespace MakFood.Customer.Domain.FriendshipAggregate.Enums
{
    public enum FiendshipStatus
    {
        [Description("درخواست داده شده")]
        Requested,

        [Description("رد شده")]
        Rejected,

        [Description("تایید شده")]
        Accepted,

        [Description("باطل شده")]
        Revoked
    }
}
