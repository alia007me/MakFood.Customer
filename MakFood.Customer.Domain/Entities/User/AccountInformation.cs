using MakFood.Customer.Domain.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MakFood.Customer.Domain.Models.Entities.User
{
    public class AccountInformation
    {
        public AccountInformation()
        {
            id = Guid.NewGuid();
            joinDate = DateOnly.FromDateTime(DateTime.Now);
            Badge = 0;
        }

        public Guid id { get; set; }
        public DateOnly joinDate { get; set; }
        public string? profilePicture { get; set; }
        public Badge Badge { get; set; }

        public void SetReplaceProfilePicture(string URL)
        {
            ValidityCheckProfileURL(URL);
            profilePicture = URL;
        }

        public void ValidityCheckProfileURL(string URL)
        {
            string UMLCheckRegex = @"((http|https)://)(www.)?" +
                                    "[a-zA-Z0-9@:%._\\+~#?&//=]" +
                                    "{2,256}\\.[a-z]" +
                                    "{2,6}\\b([-a-zA-Z0-9@:%" +
                                    "._\\+~#?&//=]*)";

            if (!Regex.IsMatch(URL, UMLCheckRegex)) throw new Exception("Your URL is not valid");
        }

        public void RemoveprofilePicture()
        {
            profilePicture = null;
        }

        public void UpgradeBadge()
        {
            Badge++;
        }

        public void DeclineBadge()
        {
            Badge--;
        }



    }
}
