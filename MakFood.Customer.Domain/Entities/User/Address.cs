using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MakFood.Customer.Domain.Models.Entities.User
{
    public class Address
    {
        public Address(string title, string streetNumber, uint houseNumber, uint unitNo, string postalCode)
        {
            id = Guid.NewGuid();

            ValidityCheckTitle(title);
            ValidityCheckStreetAddress(streetNumber);


            this.title = title;
            this.streetNumber = streetNumber;
            this.houseNumber = houseNumber;
            this.unitNo = unitNo;
            this.postalCode = postalCode;
        }

        public Guid id { get; set; }
        public string title { get; set; }
        public string streetNumber { get; set; }
        public uint houseNumber { get; set; }
        public uint unitNo { get; set; }
        public string postalCode { get; set; }

        public void ValidityCheckTitle(string title)
        {
            if (title == null) throw new Exception("Your title can't be null");
            string titleRegex = "([a-zA-Z0-9 _ \\s]+)";
            if (!Regex.IsMatch(title, titleRegex)) throw new Exception("You can only use A-Z a-z and space.");
        }

        public void ValidityCheckStreetAddress(string street)
        {
            if (street == null) throw new Exception("Your title can't be null");
            string streetAddressRegex = "([a-zA-Z0-9,،._\\s]+)";
            if (!Regex.IsMatch(street, streetAddressRegex)) throw new Exception("You can only use A-Z a-z ,space ,_.، ");
        }
        public void ValidityPostalCode(string postalCode)
        {
            if (postalCode == null) throw new Exception("Your PostalCode can't be null");
            string postalcodeRegex = "([0-9])";
            if (!Regex.IsMatch(postalCode, postalcodeRegex)) throw new Exception("you can only use 0-9");
        }
    }
}
