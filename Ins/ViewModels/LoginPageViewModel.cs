using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
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
using MvvmCross.Plugins.Messenger;

namespace Ins.Droid.ViewModels
{
    public class LoginPageViewModel:MvxViewModel
    {
        private IUserService _userService;
        private IDataBaseService _dataBaseService;

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
        
        public LoginPageViewModel(IUserService userService, IDataBaseService dataBaseService)
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
            ShowViewModel<RegistrationPageViewModel>();
        }

        void LogInViaFacebookClicked()
        {
            ShowViewModel<FacebookPageViewModel>();
        }

        void LogInClicked()
        {           
            if (_userService.IsCorrect(User))
            {
                if (!_dataBaseService.InDataBase(User)){
                    _dataBaseService.InsertIntoTableUser(User);
                }
                ShowViewModel<TabPageViewModel>();
            }
            else
            {

            }
        }        
    }
}