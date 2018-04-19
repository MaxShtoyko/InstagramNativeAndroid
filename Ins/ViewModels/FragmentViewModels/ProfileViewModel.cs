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
using Ins.Droid.Interfaces;
using Ins.Droid.Models;
using Ins.Droid.Services;
using MvvmCross.Core.ViewModels;
using Xamarin.Facebook.Login.Widget;

namespace Ins.Droid.ViewModels
{
    public class ProfileViewModel:MvxViewModel
    {
        private IUserService _userService;

        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if (SetProperty(ref _currentUser, value))
                    RaisePropertyChanged(() => _currentUser);
            }
        }
        public ProfileViewModel(IUserService userService)
        {
            _userService = userService;
            _currentUser = _userService.GetCurrentUser();
        }
    }
}