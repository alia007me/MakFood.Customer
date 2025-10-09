using MakFood.Customer.Domain.UserAggregate.Enums;
using MakFood.Customer.Infrastructure.Substructure.Exceptions;
using MakFood.Customer.Infrastructure.Substructure.Extensions;

namespace MakFood.Customer.Domain.UserAggregate
{
    public sealed class AccountInformation
    {
        public AccountInformation()
        {
            JoinDateTime = DateTime.Now;
            Badge = Badges.Normal;
        }

        public DateTime JoinDateTime { get; private set; }
        public Badges Badge { get; private set; }
        public string? ProfileThumbnail { get; set; }

        #region Behaviors

        public void Upgrade()
        {
            try
            {
                Badge = Badge.GetNextItem();
            }
            catch (Exception)
            {
                throw new ValidationFailedDomainException("Upgrade is not available!");
            }
        }

        public void Downgrade()
        {
            try
            {
                Badge = Badge.GetPreItem();
            }
            catch (Exception)
            {
                throw new ValidationFailedDomainException("Upgrade is not available!");
            }
        }
        #endregion
    }
}
