using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ins.Core.Interfaces;
using Ins.Droid.Helpers;
using Ins.Droid.Views;
using Java.IO;
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
            return auth.GetUI(ActivityHelper.BaseActivity);
        }

        public void ShowUI(object ui)
        {
            ActivityHelper.BaseActivity.StartActivity(ui as Intent);
        }
    }
}