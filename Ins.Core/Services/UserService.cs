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

        public void SetUser(FacebookProfile result)
        {
            _currentUser.FullName = result.name;
            _currentUser.Email = result.email;
            _currentUser.ProfilePictureID = result.id;
        }

        static public string GetCurrentUserName()
        {
            return _currentUser.FullName;
        }
    }
}