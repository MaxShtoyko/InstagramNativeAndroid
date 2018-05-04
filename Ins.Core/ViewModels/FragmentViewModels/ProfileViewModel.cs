using Ins.Core.Interfaces;
using Ins.Core.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using System.Collections.Generic;
using System.Windows.Input;

namespace Ins.Core.ViewModels
{
    public class ProfileViewModel : MvxViewModel
    {
        private IUserService _userService;
        private IUIService _uIService;
        private IMvxNavigationService _navigationService;

        public ICommand OnLogOut { get; private set; }

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
        public ProfileViewModel(IMvxNavigationService navigationService, IUserService userService, IUIService uIService)
        {
            _userService = userService;
            _uIService = uIService;
            _navigationService = navigationService;

            _currentUser = _userService.GetCurrentUser();

            OnLogOut = new MvxCommand(LogOutClicked);
        }

        void LogOutClicked()
        {
            var mvxBundle = new MvxBundle(new Dictionary<string, string> { { "NavigationCommand", "StackClear" } });
            _navigationService.Navigate<LoginPageViewModel>( mvxBundle );
            //Close(this);
        }
    }
}