using MakFood.Customer.Application.Service;
using System;
using System.Threading.Tasks;
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

        /// <summary>
        /// آدرس عکس پروفایل کاربر مشخص شده را به‌روزرسانی یا جایگزین می‌کند.
        /// </summary>
        public async Task SetUserProfilePictureAsync(Guid userId, string profilePictureUrl)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) throw new Exception("کاربر مورد نظر یافت نشد.");

            user.Account.UpdateReplaceProfilePicture(profilePictureUrl);

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        /// <summary>
        /// عکس پروفایل کاربر مشخص شده را حذف می‌کند (آدرس URL آن را پاک می‌کند).
        /// </summary>
        public async Task RemoveUserProfilePictureAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            if (user == null)
            {
                throw new Exception("کاربر مورد نظر برای حذف عکس پروفایل یافت نشد.");
            }

            user.Account.RemoveprofilePicture();

            _userRepository.Update(user);
            await _userRepository.SaveChangesAsync();
        }

        
    }
}