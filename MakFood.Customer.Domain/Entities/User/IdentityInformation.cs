using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MakFood.Customer.Domain.Models.Entities.User
{
    public class IdentityInformation
    {
        public IdentityInformation(string firstName, string lastName)
        {
            this.id = Guid.NewGuid();

            ValidityCheckName(firstName);
            ValidityCheckName(lastName);

            this.firstName = firstName;
            this.lastName = lastName;
        }

        public Guid id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateOnly? birthDate { get; set; }

        public void ValidityCheckName(string name)
        {
            string NameRegex = "([a-zA-Z0-9 \\s]+)";
            if (!Regex.IsMatch(name, NameRegex)) throw new Exception("You can only use A-Z a-z and space.");

        }

        public void ValidityCheckBirthDate(DateOnly birthDate)
        {
            DateOnly max = birthDate.AddYears(-150);
            if (birthDate >= DateOnly.FromDateTime(DateTime.Now) || birthDate <= max) throw new Exception("please enter valid birthDate");

        }
    }
}
