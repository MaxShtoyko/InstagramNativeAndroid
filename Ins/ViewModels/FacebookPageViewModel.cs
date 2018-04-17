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
using Ins.Interfaces;
using Ins.Models;
using Ins.Services;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using Xamarin.Facebook;

namespace Ins.ViewModels
{
    public class FacebookPageViewModel: MvxViewModel
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

        public FacebookPageViewModel(IUserService userService)
        {
            _userService = userService;
            _currentUser = _userService.GetCurrentUser();
        }
    }
}