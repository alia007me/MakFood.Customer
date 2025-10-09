using MakFood.Customer.Infrastructure.Substructure.Exceptions;

namespace MakFood.Customer.Domain.UserAggregate
{
    /// <summary>
    /// اطلاعات تماس کاربر
    /// </summary>
    public sealed class ContactInformation
    {
        /// For ORM
        private ContactInformation() { }
        public ContactInformation(string phoneNumber)
        {
            CheckPhoneNumberNullOrEmpty(phoneNumber);

            PhoneNumber = phoneNumber;
        }

        public ContactInformation(string phoneNumber, string? mail)
        {
            CheckPhoneNumberNullOrEmpty(phoneNumber);

            PhoneNumber = phoneNumber;
            Mail = mail;
        }

        public string PhoneNumber { get; private set; }
        public string? Mail { get; set; }

        #region Validations

        private void CheckPhoneNumberNullOrEmpty(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                throw new ValidationFailedDomainException("Phone number can not be empty!");
        }

        #endregion

        #region Behaviors

        public void UpdatePhoneNumber(string phoneNumber)
        {
            CheckPhoneNumberNullOrEmpty(phoneNumber);

            PhoneNumber = phoneNumber;
        }

        #endregion
    }
}
