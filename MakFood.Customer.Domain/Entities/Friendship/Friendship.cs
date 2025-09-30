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
            Id = Guid.NewGuid();
            ValidityNickName(nickNameOfSender);
            ValidityNickName(nickNameOfReceiver);

            NickNameOfReceiver = nickNameOfReceiver;
            NickNameOfSender = nickNameOfSender;
            this.Userid = userid;
            this.OtherUserid = otherUserid;
        }

        public Guid Id { get; set; }
        public string NickNameOfReceiver { get; set; }
        public string NickNameOfSender { get; set; }
        public Guid Userid { get; set; }
        public Guid OtherUserid { get; set; }
        public bool Accepted { get; set; }
        public bool ActiveFriend { get; set; }
        public MatchingState MatchingState { get; private set; }

        public void ValidityNickName(string nickName)
        {
            if (nickName == null) throw new Exception("nickName can't be null");
            string nameRegex = "([a-zA-Z0-9 \\s]+)";
            if (!Regex.IsMatch(nickName, nameRegex)) throw new Exception("You can only use A-Z a-z and space.");
        }
        public void SetState(MatchingState state)
        {
            MatchingState = state;
        }

    }
}
