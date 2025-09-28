using MakFood.Customer.Domain.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MakFood.Customer.Domain.Models.Entities.Friendship
{
    public class Friendship
    {
        public Friendship(string nickNameOfReceiver, string nickNameOfSender, Guid userid, Guid otherUserid)
        {
            id = Guid.NewGuid();
            ValidityNickName(nickNameOfSender);
            ValidityNickName(nickNameOfReceiver);

            NickNameOfReceiver = nickNameOfReceiver;
            NickNameOfSender = nickNameOfSender;
            this.userid = userid;
            this.otherUserid = otherUserid;
        }

        public Guid id { get; set; }
        public string NickNameOfReceiver { get; set; }
        public string NickNameOfSender { get; set; }
        public Guid userid { get; set; }
        public Guid otherUserid { get; set; }
        public bool accepted { get; set; }
        public bool activeFriend { get; set; }
        public MatchingState matchingState { get; private set; }

        public void ValidityNickName(string nickName)
        {
            if (nickName == null) throw new Exception("nickName can't be null");
            string NameRegex = "([a-zA-Z0-9 \\s]+)";
            if (!Regex.IsMatch(nickName, NameRegex)) throw new Exception("You can only use A-Z a-z and space.");
        }
        public void SetState(MatchingState state)
        {
            matchingState = state;
        }

    }
}
