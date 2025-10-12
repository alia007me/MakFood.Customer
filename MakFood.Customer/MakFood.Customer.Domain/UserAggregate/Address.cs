using MakFood.Customer.Domain.Base;
using MakFood.Customer.Infrastructure.Substructure.Exceptions;
using System.Text.RegularExpressions;

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
            CheckTitleRegexNullOrEmpty(title);
            CheckStreetRegexNullOrEmpty(street);
            CheckPlaqueRegexNullOrEmpty(plaque);
            CheckPostalCodeRegexNullOrEmpty(postalCode);


            Id = Guid.NewGuid();
            Title = title;
            Street = street;
            Plaque = plaque;
            PostalCode = postalCode;
        }

        public Address(string title, string street, uint plaque, string postalCode, uint? unitNo)
        {
            CheckTitleRegexNullOrEmpty(title);
            CheckStreetRegexNullOrEmpty(street);
            CheckPlaqueRegexNullOrEmpty(plaque);
            CheckPostalCodeRegexNullOrEmpty(postalCode);

            Id = Guid.NewGuid();
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

        #region NullOrEmptyValidations

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

        private void CheckPlaqueNullOrEmpty(uint plaque)
        {
            if (plaque == null)
                throw new ValidationFailedDomainException("Address plaque can not be empty!");
        }

        private void CheckPostalCodeNullOrEmpty(string postalCodel)
        {
            if (string.IsNullOrWhiteSpace(postalCodel))
                throw new ValidationFailedDomainException("Address postal code can not be empty!");
        }

        #endregion

        #region RegexValidations
        private void CheckTitleRegex(string title)
        {
            if (!Regex.IsMatch(title, "^[a-zA-Z0-9,،.'\\s]{3,50}$"))
                throw new ValidationFailedDomainException("Address title format is not valid!");
        }

        private void CheckStreetRegex(string street)
        {
            if (!Regex.IsMatch(street, "^[a-zA-Z0-9,،.\\s]{3,50}$"))
                throw new ValidationFailedDomainException("Address street format is not valid!");
        }

        private void CheckPostalCodeRegex(string postalCode)
        {
            if (!Regex.IsMatch(postalCode, "^[0-9]{10}$"))
                throw new ValidationFailedDomainException("Address postal code format is not valid!");
        }


        #endregion

        #region RegexNullOrEmptyValidations

        private void CheckTitleRegexNullOrEmpty(string title)
        {
            CheckTitleNullOrEmpty(title);
            CheckTitleRegex(title);
        }
        private void CheckStreetRegexNullOrEmpty(string street)
        {
            CheckStreetNullOrEmpty(street);
            CheckStreetRegex(street);
        }
        private void CheckPlaqueRegexNullOrEmpty(uint plaque)
        {
            CheckPlaqueNullOrEmpty(plaque);
        }

        private void CheckPostalCodeRegexNullOrEmpty(string postalCode)
        {
            CheckPostalCodeNullOrEmpty(postalCode);
            CheckPostalCodeRegex(postalCode);
        }

        #endregion

        #region Behaviors

        public void UpdateAddress(Address address)
        {
            CheckTitleRegexNullOrEmpty(address.Title);
            CheckStreetRegexNullOrEmpty(address.Street);
            CheckPlaqueRegexNullOrEmpty(address.Plaque);
            CheckPostalCodeRegexNullOrEmpty(address.PostalCode);

            Title = address.Title;
            Street = address.Street;
            Plaque = address.Plaque;
            PostalCode = address.PostalCode;
            UnitNo = address.UnitNo;

        }

        #endregion
    }
}
