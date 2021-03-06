﻿using Ins.Core.Interfaces;
using Ins.Core.Models;
using Ins.Droid.Helpers;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System.Windows.Input;

namespace Ins.Core.ViewModels
{
    public class LoginPageViewModel: BaseMvxViewModel
    {
        private readonly IUserService _userService;
        private readonly IDataBaseService<User> _dataBaseService;

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

        public ICommand OnLogIn { get; private set; }
        public ICommand OnSignUp { get; private set; }
        public ICommand OnLogInViaFacebook { get; private set; }
        
        public LoginPageViewModel(IUserService userService, IDataBaseService<User> dataBaseService)
        {
            _userService = userService;
            _dataBaseService = dataBaseService;

            _user = _userService.GetCurrentUser();
           _dataBaseService.CreateDataBase();

            OnLogIn = new MvxCommand(LogInClicked);
            OnSignUp = new MvxCommand(SignUpClicked);
            OnLogInViaFacebook = new MvxCommand(LogInViaFacebookClicked);
        }

        void SignUpClicked()
        {
            _userService.Reset();
            ShowViewModel<RegistrationPageViewModel>();
        }

        void LogInViaFacebookClicked()
        {
            ShowViewModel<FacebookPageViewModel>();
        }

        void LogInClicked()
        {           
            if ( _userService.IsCorrect(User) && _dataBaseService.InDataBase(User.Email) ){
                ShowViewModel<TabPageViewModel>();
            }
            else{
                Error = "Error, please check the entered information!";
            }
        }  
    }
}