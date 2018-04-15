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
using Ins.Models;
using Ins.Services;
using MvvmCross.Core.ViewModels;

namespace Ins.ViewModels
{
    public class RegistrationViewModel:MvxViewModel 
    {
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
        

        public RegistrationViewModel()
        {
            _user = UserService.getCurrentUser();

            OnSignUp = new MvxCommand(SignUpClicked);
        }

        void SignUpClicked()
        {
            ShowViewModel<TabbedViewModel>();
        }
    }
}