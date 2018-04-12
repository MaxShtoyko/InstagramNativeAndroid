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
using MvvmCross.Core.ViewModels;

namespace Ins.ViewModels
{
    public class LoginPageViewModel:MvxViewModel
    {
        public ICommand OnLogIn
        {
            get => new MvxCommand(() => ShowViewModel<CameraViewModel>(), () => true);
        }
    }
}