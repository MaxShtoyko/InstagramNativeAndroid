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
        private readonly IUserService _userService;
        private readonly IUIService _uIService;
        private readonly IMvxNavigationService _navigationService;

        public ICommand OnEditProfile { get; private set; }

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
        public ProfileViewModel(IUserService userService, IUIService uIService, IMvxNavigationService navigationService)
        {
            _userService = userService;
            _uIService = uIService;
            _navigationService = navigationService;

            _currentUser = _userService.GetCurrentUser();

            OnEditProfile = new MvxCommand(EditProfileClicked);
        }
              
        private void EditProfileClicked()
        {
            ShowViewModel<SettingPageViewModel>();
        }
    }
}