using Ins.Core.Interfaces;
using Ins.Core.Models;
using Ins.Droid.Extensions;
using System;

namespace Ins.Droid.Services
{
    public class UserService:IUserService
    {
        static private User _currentUser;

        public User GetCurrentUser()
        {
            if (_currentUser == null)
                _currentUser = new User();

            return _currentUser;
        }

        public bool IsCorrect( User user )
        {
            if (String.IsNullOrWhiteSpace(user.Email) || String.IsNullOrWhiteSpace(user.Password)){
                return false;
            }

            return user.Email.IsEmail() && user.Password.Length > 6;
        }

        public void Reset()
        {
            _currentUser.FullName = String.Empty;
            _currentUser.Email = String.Empty;
            _currentUser.Login = String.Empty;
            _currentUser.Password = String.Empty;
        }

        public void SetUser(User user)
        {
            _currentUser.FullName = user.FullName;
            _currentUser.Email = user.Email;
            _currentUser.ProfilePictureID = user.ProfilePictureID;
            _currentUser.PictureData.Data.Url = user.PictureData.Data.Url;
        }

        static public string GetCurrentUserName()
        {
            return _currentUser.FullName;
        }

        static public string GetUserId()
        {
            return _currentUser.ProfilePictureID;
        }
    }
}