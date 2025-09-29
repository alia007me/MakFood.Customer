using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MakFood.Customer.Domain.Models.Entities.User
{
    public class ContactInformation
    {
        public ContactInformation(string phoneNumber)
        {
            id = Guid.NewGuid();
            ValidityCheckphoneNumber(phoneNumber);

            this.phoneNumber = phoneNumber;
        }
        public Guid id { get; set; }
        public string phoneNumber { get; set; }
        public string? email { get; set; }

        public void ValidityCheckphoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) throw new Exception("Phone Number is Empty or Null");

            var Reg = @"^(\+98|0)\d{10}$";
            if (!Regex.IsMatch(phoneNumber, Reg)) throw new Exception("pls enter the valid phone number");

        }
        public void ValidityCheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new Exception("Email is empty or null");

            var Reg = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; ;
            if (!Regex.IsMatch(email, Reg)) throw new Exception("pls enter the valid Email");

        }
    }
}
