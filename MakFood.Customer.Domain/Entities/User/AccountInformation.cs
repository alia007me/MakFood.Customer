using MakFood.Customer.Domain.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MakFood.Customer.Domain.Helper;
using MakFood.Customer.Domain.Helper.HashHelper;

namespace MakFood.Customer.Domain.Models.Entities.User
{
    /// <summary>
    /// این کلاس اطلاعات اکانت یک فرد را ذخیره می کند
    /// </summary>
    /// <remarks>
    /// این مدل شامل آیدی، جوین دیت، و نشان می باشد
    /// متد برای ثبت بدج، حذف پروفایل و ست یا آپدیت کردن پروفایل هم دارد
    /// </remarks>
    public class AccountInformation
    {
        private string? _password;
        /// <summary>
        /// کانستراکتور بدون مقدار ورودی برای ثبت مقدایر اولیه
        /// </summary>
        /// <remarks>
        /// با توجه به منطق پروژه در این کانستراکتور مقدار ورودی گرفتن لازم نبود
        /// </remarks>
        public AccountInformation(string userName, string password, string reWritePassword)
        {

            ValidityUserName(userName);
            ValidityPassword(password);
            CheckPasswordRewrite(password, reWritePassword);

            Id = Guid.NewGuid();
            this.UserName = userName;
            this.Password = password;

            JoinDate = DateOnly.FromDateTime(DateTime.Now);
            Badge = Badge.Normal;
        }

        public Guid Id { get; private init; }
        public string UserName { get; private set; }
        private string Password
        {
            set
            {
                _password = HashHelper.ComputeSha256Hash(value);
            }
        }
        public DateOnly JoinDate { get; private set; }
        public string? ProfilePicture { get;private set; }
        public Badge Badge { get; private set; }

        /// <summary>
        /// یوزر نیم رو برسی می کنه
        /// </summary>
        /// <param name="username"></param>
        /// <exception cref="Exception"></exception>
        public void ValidityUserName(string username)
        {
            if (username == null) throw new Exception("Your userName can't be Null");
            string userNameRegex = "^[A-Za-z][A-Za-z0-9_]{2,19}$\r\n";
            if (!Regex.IsMatch(username, userNameRegex)) throw new Exception("Your UserName is not Valid Between 2 - 19 char and A-z and _ is valid");

        }

        /// <summary>
        /// پسوورد رو برسی می کنه
        /// </summary>
        /// <param name="password"></param>
        /// <exception cref="Exception"></exception>
        /// <remarks>فقط بیشتر از 6 کاراکتر باشه کافیه</remarks>
        public void ValidityPassword(string password)
        {
            if (password == null) throw new Exception("Your password can't be Null");
            string passwordRegex = "^.{6,}$\r\n";
            if (!Regex.IsMatch(password, passwordRegex)) throw new Exception("at list 6 character");
        }

        /// <summary>
        /// یکسان بودن پسورد با تکرارش رو برسی می کنه
        /// </summary>
        /// <param name="password"></param>
        /// <param name="rewritepassword"></param>
        /// <exception cref="Exception"></exception>
        public void CheckPasswordRewrite(string password, string rewritepassword)
        {
            if (password != rewritepassword) throw new Exception("password and replay of it are not same");
        }

        /// <summary>
        /// یوزر نیم را آپدیت می کند
        /// </summary>
        /// <param name="userName"></param>
        public void UpdateUserName(string userName)
        {
            ValidityUserName(userName);
            UserName = userName;
        }

        /// <summary>
        /// پسورد یوزر رو بعد از برسی شروط آپدیت می کنه
        /// </summary>
        /// <param name="Previouspassword">رمز قبلی</param>
        /// <param name="newPassword">رمز جدید</param>
        /// <exception cref="Exception"></exception>
        public void UpdateUserPassword(string Previouspassword, string newPassword)
        {
            if (CheckPassword(Previouspassword)) throw new Exception("your Previous password is wrong");
            ValidityPassword(newPassword);

            Password = newPassword;

        }

        /// <summary>
        /// برسی می کنه هش شده پسوردی که وارد کرده با هش ذخیره شده یکسان هست یا نه
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CheckPassword(string? password)
        {
            return HashHelper.VerifySha256Hash(password, _password);
        }


        /// <summary>
        /// این متد عکس پروفایل جدید برای کاربر ثبت می کند
        /// </summary>
        /// <param name="url"></param>
        /// <remarks>
        /// در ابتدا صحت سنجی انجام می شود و پس از آن عکس جدید جای عکس قبلی را می گیرد
        /// </remarks>
        public void UpdateReplaceProfilePicture(string url)
        {
            ProfilePicture = url;
        }

        /// <summary>
        ///  این متد عکس پروفایل را به صورت کامل حذف می کند و عکس پروفایل خالی می ماند
        /// </summary>
        public void RemoveprofilePicture()
        {
            ProfilePicture = null;
        }

        /// <summary>
        /// این متد بدج رو ست می کنه
        /// </summary>
        /// <param name="badge"></param>
        /// <remarks>
        /// می باشد Badge ورودی این متد از یک اینام به اسم 
        /// </remarks>
        public void SetBadge(Badge badge)
        {
            Badge = badge;
        }
    }
}
