using MakFood.Customer.Infrastructure.Substructure.Exceptions;
using System.Data;

namespace MakFood.Customer.Domain.UserAggregate
{
    /// <summary>
    /// اطلاعات هویتی فرد
    /// </summary>
    public sealed class IdentityInformation
    {
        /// For ORM
        private IdentityInformation() { }
        public IdentityInformation(string firstName, string lastName)
        {
            CheckFirstNameNullOrEmpty(firstName);
            CheckLastNameNullOrEmpty(lastName);

            FirstName = firstName;
            LastName = lastName;
        }
        public IdentityInformation(string firstName, string lastName, DateOnly? birthDate)
        {
            CheckFirstNameNullOrEmpty(firstName);
            CheckLastNameNullOrEmpty(lastName);
            CheckBirthDate(birthDate);

            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateOnly? BirthDate { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        #region Validations

        private void CheckFirstNameNullOrEmpty(string firstName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ValidationFailedDomainException("First name can not be empty!");
        }

        private void CheckLastNameNullOrEmpty(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ValidationFailedDomainException("Last name can not be empty!");
        }

        private void CheckBirthDate(DateOnly? birthDate)
        {
            if (birthDate.HasValue)
            {
                DateOnly minLimit = DateOnly.FromDateTime(DateTime.Now).AddYears(-150);
                DateOnly maxLimit = DateOnly.FromDateTime(DateTime.Now).AddDays(-1);

                if (birthDate < minLimit || birthDate > maxLimit) throw new Exception("Invalid BitrhDate");
            }

        }

        #endregion

        #region Behaviors

        
        public void Update(IdentityInformation newidentityInformation)
        {

            CheckFirstNameNullOrEmpty(newidentityInformation.FirstName);
            CheckLastNameNullOrEmpty(newidentityInformation.LastName);
            CheckBirthDate(newidentityInformation.BirthDate);

            FirstName = newidentityInformation.FirstName;
            LastName = newidentityInformation.LastName;
            BirthDate = newidentityInformation.BirthDate;

        }



        #endregion
    }
}
