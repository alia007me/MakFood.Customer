using MakFood.Customer.Domain.Base;
using MakFood.Customer.Infrastructure.Substructure.Exceptions;
using System.Data;

namespace MakFood.Customer.Domain.UserAggregate
{
    public class UserAccount : BaseEntity<Guid>
    {
        private List<Address> _addresses = new List<Address>();

        private UserAccount() { }
        public UserAccount(ContactInformation contactInformation, IdentityInformation identityInformation, AccountInformation accountInformation)
        {
            Id = Guid.NewGuid();

            ContactInformation = contactInformation;
            IdentityInformation = identityInformation;
            AccountInformation = accountInformation;
        }


        /// <summary>
        /// آدرس های یک کاربر
        /// </summary>
        public IEnumerable<Address> Addresses => _addresses.AsReadOnly();

        /// <summary>
        /// اطلاعات تماسی کاربر
        /// </summary>
        public ContactInformation ContactInformation { get; private set; }

        /// <summary>
        /// اطلاعات هویتی کاربر
        /// </summary>
        public IdentityInformation IdentityInformation { get; private set; }

        /// <summary>
        /// اطلاعات حساب کاربر
        /// </summary>
        public AccountInformation AccountInformation { get; private set; }

        #region Validations

        private void CheckRepeatedAddressByTitle(Address address)
        {
            if (_addresses.Any(c => c.Title == address.Title))
                throw new ValidationFailedDomainException("Address is repeated!");
        }

        #endregion

        #region Behaviors

        public void AddAddress(Address address)
        {
            CheckRepeatedAddressByTitle(address);

            _addresses.Add(address);
        }

        public void RemoveAddress(Address address)
        {
            _addresses.Remove(address);
        }



        #endregion
    }
}
