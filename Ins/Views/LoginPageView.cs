using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace Ins.Droid.Views
{
    [Activity(Label = "LoginPageView",Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen", MainLauncher = true)]
    public class LoginPageView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginPage);

            // Create your application here
        }
    }
}