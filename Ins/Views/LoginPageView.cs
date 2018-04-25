﻿
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;

namespace Ins.Droid.Views
{
    [Activity(Label = "LoginPageView",Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen", MainLauncher = true)]
    public class LoginPageView : BaseMvxView
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LoginPage);

            var header = FindViewById<TextView>(Resource.Id.headerView);
            var emailEntry = FindViewById<EditText>(Resource.Id.emailEntry);
            var passwordEntry = FindViewById<EditText>(Resource.Id.passwordEntry);
            var loginView = FindViewById<RelativeLayout>(Resource.Id.loginView);
            var signUpButton = FindViewById<Button>(Resource.Id.signUpButton);
            var logInButton = FindViewById<Button>(Resource.Id.logInButton);
            var logInViaFacebookButton = FindViewById<Button>(Resource.Id.logInViaFacebookButton);

            Typeface headerFont = Typeface.CreateFromAsset(Assets, "fonts/9424.ttf");
            header.SetTypeface(headerFont, TypefaceStyle.Normal);

            Typeface robotoLight = Typeface.CreateFromAsset(Assets, "fonts/Roboto-Light.ttf");
            emailEntry.SetTypeface(robotoLight, TypefaceStyle.Normal);

            emailEntry.SetTypeface(robotoLight, TypefaceStyle.Normal);
            passwordEntry.SetTypeface(robotoLight, TypefaceStyle.Normal);
            signUpButton.SetTypeface(robotoLight, TypefaceStyle.Normal);

            passwordEntry.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            emailEntry.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            loginView.SetBackgroundResource(Resource.Drawable.LoginPageStyle);
            logInButton.SetBackgroundResource(Resource.Drawable.ButtonStyle);
            logInViaFacebookButton.SetBackgroundResource(Resource.Drawable.FacebookButtonStyle);
            // Create your application here
        }
    }
}