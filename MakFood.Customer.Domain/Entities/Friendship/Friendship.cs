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
    /// <summary>
    /// این کلاس نمایانگر رابطه‌ی دوستی بین دو کاربر است.
    /// شامل وضعیت درخواست، فعال بودن دوستی و اطلاعات دو طرف می‌باشد.
    /// </summary>
    public class Friendship
    {
            /// <summary>
            /// سازنده‌ی کلاس Friendship. 
            /// وظیفه‌ی آن مقداردهی اولیه مقادیر اصلی و اعتبارسنجی nicknameها است.
            /// </summary>
            /// <param name="nickNameOfReceiver">نام مستعار دریافت‌کننده‌ی درخواست</param>
            /// <param name="nickNameOfSender">نام مستعار ارسال‌کننده‌ی درخواست</param>
            /// <param name="userId">شناسه‌ی کاربر اصلی</param>
            /// <param name="otherUserId">شناسه‌ی کاربر مقابل</param>
            
        public Friendship(string nickNameOfReceiver, string nickNameOfSender, Guid userId, Guid otherUserId)
        {

            Id = Guid.NewGuid();
            ValidityNickName(nickNameOfSender);
            ValidityNickName(nickNameOfReceiver);

            this.NickNameOfReceiver = nickNameOfReceiver;
            this.NickNameOfSender = nickNameOfSender;
            this.UserId = userId;
            this.OtherUserId = otherUserId;
      
            this.Accepted = false; 
            this.ActiveFriend = false;
            this.MatchingState = MatchingState.Requested;
        }

        public Guid Id { get; init; }
        /// <summary>
        /// نام مستعار دریافت کننده درخواست 
        /// </summary>
        public string NickNameOfReceiver { get;private set; }
        /// <summary>
        /// نام مستعار ارسال کننده درخواست 
        /// </summary>
        public string NickNameOfSender { get;private set; }
        public Guid UserId { get;private set; }
        public Guid OtherUserId { get;private set; }
        public bool Accepted { get;private set; }
        public bool ActiveFriend { get;private set; }
        /// <summary>
        /// وضعیت درخواست دوستی : در انتطار * قبول شده * رد شده
        /// </summary>
        public MatchingState MatchingState { get; private set; }
        /// <summary>
        ///  اعتبار سنجی nickname با استفاده از regex 
        /// </summary>
        /// <param name="nickName"></param>
        /// <exception cref="Exception"></exception>
        private void ValidityNickName(string nickName)
        {
            if (nickName == null) throw new Exception("nickName can't be null");
            string nameRegex = "([a-zA-Z0-9 \\s]+)";
            if (!Regex.IsMatch(nickName, nameRegex)) throw new Exception("You can only use A-Z a-z and space.");
        }

        /// <summary>
        /// وضعیت  درخواست دوستی را نشان میدهد
        /// </summary>
        /// <param name="state"> newState</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void SetState(MatchingState state)
        {
            if (MatchingState == MatchingState.Accepted && state == MatchingState.Requested)
                throw new InvalidOperationException("cannot revert Acceptrd to Requested");

            MatchingState = state;
            Accepted = (state == MatchingState.Accepted);
            ActiveFriend = (state == MatchingState.Accepted);

        }
         ///<summary>
         ///لغو یا حذف دوستی 
         ///</summary>
         public void Cancel()
        {
            MatchingState = MatchingState.Rejected;
            Accepted = false;
            ActiveFriend = false;
        }


    }
}
