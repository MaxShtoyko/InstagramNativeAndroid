using Ins.Core.Interfaces;
using Ins.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Ins.Core.ViewModels
{
    public class SettingPageViewModel:MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IUserService _userService;

        public ICommand OnLogOut { get; private set; }
		public ICommand OnSaveChanges { get; private set; }

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

        public SettingPageViewModel(IMvxNavigationService navigationService, IUserService userService)
        {
            _navigationService = navigationService;
            _userService = userService;

            _currentUser = _userService.GetCurrentUser();

            OnLogOut = new MvxCommand(LogOutClicked);
			OnSaveChanges = new MvxCommand(SaveChangesClicked);
        }

        private void LogOutClicked()
        {
            var mvxBundle = new MvxBundle(new Dictionary<string, string> { { "NavigationCommand", "StackClear" } });
            _navigationService.Navigate<LoginPageViewModel>(mvxBundle);
            _userService.Reset();
        }

        private void SaveChangesClicked()
        {
			_userService.SetUser(CurrentUser);
        }
      
    }
}
