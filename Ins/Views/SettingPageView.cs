using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace Ins.Droid.Views
{
    [Activity(Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen")]
    public class SettingPageView : BaseMvxView
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SettingPage);
            SetViews();
            // Create your application here
        }

        void SetViews()
        {
            Typeface robotoLightFont = Typeface.CreateFromAsset(Assets, "fonts/Roboto-Light.ttf");

            var emailEditText = FindViewById<EditText>(Resource.Id.registrationEmail);
            var nameEditText = FindViewById<EditText>(Resource.Id.registrationFullName);
            var loginEditText = FindViewById<EditText>(Resource.Id.registrationLogin);
            var settingPageView = FindViewById<RelativeLayout>(Resource.Id.settingPageView);

            emailEditText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
            nameEditText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
            loginEditText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);

            emailEditText.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            nameEditText.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            loginEditText.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            settingPageView.SetBackgroundResource(Resource.Drawable.LoginPageStyle);

            loginEditText.SetHintTextColor(Color.Gray);
            nameEditText.SetHintTextColor(Color.Gray);
            emailEditText.SetHintTextColor(Color.Gray);
        }
    }
}