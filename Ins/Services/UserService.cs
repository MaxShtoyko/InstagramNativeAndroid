using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ins.Extensions;
using Ins.Interfaces;
using Ins.Models;

namespace Ins.Services
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
            _currentUser.ProfilePictureView.ProfileId = result.id;
        }
    }
}