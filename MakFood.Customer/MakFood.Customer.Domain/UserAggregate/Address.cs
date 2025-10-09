using MakFood.Customer.Domain.Base;
using MakFood.Customer.Infrastructure.Substructure.Exceptions;

namespace MakFood.Customer.Domain.UserAggregate
{
    /// <summary>
    /// آدرس کاربر
    /// </summary>
    public sealed class Address : BaseEntity<Guid>
    {
        /// For ORM
        private Address() { }
        public Address(string title, string street, uint plaque, string postalCode)
        {
            CheckTitleNullOrEmpty(title);
            CheckStreetNullOrEmpty(title);
            CheckPlaqueNullOrEmpty(title);
            CheckPostalCodeNullOrEmpty(title);

            Id = Guid.NewGuid();
            Title = title;
            Street = street;
            Plaque = plaque;
            PostalCode = postalCode;
        }

        public Address(string title, string street, uint plaque, string postalCode, uint? unitNo)
        {
            CheckTitleNullOrEmpty(title);
            CheckStreetNullOrEmpty(title);
            CheckPlaqueNullOrEmpty(title);
            CheckPostalCodeNullOrEmpty(title);

            Title = title;
            Street = street;
            Plaque = plaque;
            PostalCode = postalCode;
            UnitNo = unitNo;
        }

        public string Title { get; private set; }
        public string Street { get; private set; }
        public uint Plaque { get; private set; }
        public string PostalCode { get; private set; }
        public uint? UnitNo { get; set; }

        #region Validations

        private void CheckTitleNullOrEmpty(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ValidationFailedDomainException("Address title can not be empty!");
        }

        private void CheckStreetNullOrEmpty(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ValidationFailedDomainException("Address street can not be empty!");
        }

        private void CheckPlaqueNullOrEmpty(string plaque)
        {
            if (string.IsNullOrWhiteSpace(plaque))
                throw new ValidationFailedDomainException("Address plaque can not be empty!");
        }

        private void CheckPostalCodeNullOrEmpty(string postalCodel)
        {
            if (string.IsNullOrWhiteSpace(postalCodel))
                throw new ValidationFailedDomainException("Address postal code can not be empty!");
        }

        #endregion

        #region Behaviors

        public void UpdateAddress(string title, string street, uint plaque, string postalCode)
        {
            CheckTitleNullOrEmpty(title);
            CheckStreetNullOrEmpty(title);
            CheckPlaqueNullOrEmpty(title);
            CheckPostalCodeNullOrEmpty(title);

            Title = title;
            Street = street;
            Plaque = plaque;
            PostalCode = postalCode;
        }

        #endregion
    }
}
