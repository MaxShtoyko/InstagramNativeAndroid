using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;

namespace Ins.Droid.Views
{
    [Activity(Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen")]
    public class RegistrationPageView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RegistrationPage);

            SetViews();
            // Create your application here
        }

        protected override void OnRestart()
        {
            base.OnRestart();

            var errorText = FindViewById<TextView>(Resource.Id.errorText);
            errorText.Text = string.Empty;
        }

        private void SetViews()
        {
            var NameEditText = FindViewById<EditText>(Resource.Id.registrationFullName);
            var LoginEditText = FindViewById<EditText>(Resource.Id.registrationLogin);
            var EmailEditText = FindViewById<EditText>(Resource.Id.registrationEmail);
            var PasswordEditText = FindViewById<EditText>(Resource.Id.registrationPassword);
            var signUpButton = FindViewById<Button>(Resource.Id.signUpButton);
            var registrationView = FindViewById<RelativeLayout>(Resource.Id.registrationView);
            var registrationHeader = FindViewById<TextView>(Resource.Id.registrationHeader);

            Typeface robotoLightFont = Typeface.CreateFromAsset(Assets, "fonts/Roboto-Light.ttf");

            NameEditText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
            LoginEditText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
            EmailEditText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
            PasswordEditText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
            signUpButton.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
            registrationHeader.SetTypeface(robotoLightFont, TypefaceStyle.Normal);

            NameEditText.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            LoginEditText.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            EmailEditText.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            PasswordEditText.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            registrationView.SetBackgroundResource(Resource.Drawable.LoginPageStyle);
        }
    }
}