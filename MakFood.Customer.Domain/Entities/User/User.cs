using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakFood.Customer.Domain.Models.Entities.User
{
    public class UserAccount
    {
        public UserAccount(IdentityInformation identity, AccountInformation account, ContactInformation contactinfo, List<Address> addresses)
        {
            id = Guid.NewGuid();

            this.identity = identity;
            this.account = account;
            this.contactinfo = contactinfo;
            this.addresses = addresses;
        }

        public Guid id { get; set; }
        public IdentityInformation identity { get; set; }
        public AccountInformation account { get; set; }
        public ContactInformation contactinfo { get; set; }
        public List<Address> addresses { get; set; }


    }
}
