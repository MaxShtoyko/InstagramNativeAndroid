using Ins.Core.Interfaces;
using Ins.Core.Models;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Ins.Core.ViewModels
{
    public class ProfileViewModel : MvxViewModel
    {
        private IUserService _userService;
        private IUIService _uIService;

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
        public ProfileViewModel(IUserService userService, IUIService uIService)
        {
            _userService = userService;
            _uIService = uIService;

            _currentUser = _userService.GetCurrentUser();

            OnLogOut = new MvxCommand(LogOutClicked);
        }

        void LogOutClicked()
        {
            Close(this);
        }
    }
}