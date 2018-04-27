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
using Ins.Core.Interfaces;
using Ins.Droid.Views;
using MvvmCross.Droid.Views;
using Xamarin.Auth;

namespace Ins.Droid.Services
{
    [Activity(Label = "UIService")]
    public class UIService : IUIService
    {
        public void DismissUI()
        {
          
        }

        public object GetUI(OAuth2Authenticator auth)
        {
            return auth.GetUI(LoginPageView.Instance);
        }

        public void ShowUI(object ui)
        {
            LoginPageView.Instance.StartActivity(ui as Intent);
        }
    }
}