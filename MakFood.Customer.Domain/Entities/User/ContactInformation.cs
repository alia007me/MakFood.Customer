﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MakFood.Customer.Domain.Models.Entities.User
{
    /// <summary>
    /// این کلاس اطلاعات ارتباطی مربوط به کاربر را ذخیره می کند
    /// </summary>
    /// <remarks>
    /// این کلاس شامل شامل ایمیل و شماره تلفن و همچنین دو متد صحت سنجی برای هر دو و یک متد برای ذخیره متد جدید می باشد
    /// </remarks>
    public class ContactInformation
    {
        /// <summary>
        /// این کانستراکتور فقط شماره تلفن را به عنوان مورد ضروری از کاربر دریافت می کند
        /// </summary>
        /// <param name="phoneNumber">شماره تلفن کاربر</param>
        public ContactInformation(string phoneNumber)
        {
            Id = Guid.NewGuid();
            ValidityCheckphoneNumber(phoneNumber);

            this.PhoneNumber = phoneNumber;
        }
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }

        /// <summary>
        /// این متد شماره تلفن را صحت سنجی می کند
        /// </summary>
        /// <param name="phoneNumber">شماره تلفن</param>
        /// <exception cref="Exception">شماره تلفن نباید نال، خالی، و خارج از قالب شماره تلفن در ایران باشد</exception>
        public void ValidityCheckphoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) throw new Exception("Phone Number is Empty or Null");

            var reg = @"^(\+98|0)\d{10}$";
            if (!Regex.IsMatch(phoneNumber, reg)) throw new Exception("pls enter the valid phone number");

        }

        /// <summary>
        /// این متد ایمیل را صحت سنجی می کند
        /// </summary>
        /// <param name="email">ایمیل</param>
        /// <exception cref="Exception">ایمیل نباید نال، خالی، و خارج از قالب ایمیل باشد</exception>
        public void ValidityCheckEmail(string email)
        {
            if (string.IsNullOrEmpty(email)) throw new Exception("Email is empty or null");

            var reg = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; ;
            if (!Regex.IsMatch(email, reg)) throw new Exception("pls enter the valid Email");

        }

        /// <summary>
        /// این متد ابتدا ایمیل را صحت سنجی کرده و در جایگاه ایمیل قرار می دهد
        /// </summary>
        /// <param name="email">ایمیل</param>
        public void SetReplaceEmail(string email)
        {
            ValidityCheckEmail(email);
            Email = email;
        }
    }
}
