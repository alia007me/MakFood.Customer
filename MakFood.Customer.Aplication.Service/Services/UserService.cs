using MakFood.Customer.Aplication.Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MakFood.Customer.Infrstructure.DataAccess;
using MakFood.Customer.Domain.Interfaces;

namespace MakFood.Customer.Application.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // پیاده سازی متد تنظیم/جایگزینی (از قبل آماده شده):
        public async Task SetUserProfilePictureAsync(Guid userId, string profilePictureUrl)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) throw new Exception("کاربر مورد نظر یافت نشد.");

            // 👈 فراخوانی متد جدید دامین (UpdateReplaceProfilePicture)
            user.Account.UpdateReplaceProfilePicture(profilePictureUrl);

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        // ۲. حذف عکس پروفایل
        public async Task RemoveUserProfilePictureAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("کاربر مورد نظر برای حذف عکس پروفایل یافت نشد.");
            }

            // 👈 فراخوانی متد جدید دامین (RemoveprofilePicture)
            // توجه: نام در دامین شما با p کوچک است، که با استاندارد C# مغایرت دارد اما اینجا باید از آن استفاده شود.
            user.Account.RemoveprofilePicture();

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

    }
}
