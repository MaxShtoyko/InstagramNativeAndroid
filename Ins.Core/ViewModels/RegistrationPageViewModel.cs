using Ins.Core.Interfaces;
using Ins.Core.Models;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Ins.Core.ViewModels
{
    public class RegistrationPageViewModel:MvxViewModel
    {
        private IUserService _userService;

        private User _user;
        public User User
        {
            get => _user;
            set
            {
                if (SetProperty(ref _user, value))
                    RaisePropertyChanged(() => _user);
            }
        }

        public ICommand OnSignUp { get; private set; }
        
        public RegistrationPageViewModel(IUserService userService)
        {
            _userService = userService;
            _user = _userService.GetCurrentUser();

            OnSignUp = new MvxCommand(SignUpClicked);
        }

        void SignUpClicked()
        {
            ShowViewModel<TabPageViewModel>();
        }
    }
}