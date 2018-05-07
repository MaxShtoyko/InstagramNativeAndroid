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
            SetFonts();
            // Create your application here
        }

        void SetFonts()
        {
            Typeface robotoLightFont = Typeface.CreateFromAsset(Assets, "fonts/Roboto-Light.ttf");

            var emailEditText = FindViewById<EditText>(Resource.Id.registrationEmail);
            var nameEditText = FindViewById<EditText>(Resource.Id.registrationFullName);
            var loginEditText = FindViewById<EditText>(Resource.Id.registrationLogin);

            emailEditText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
            nameEditText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
            loginEditText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);

            loginEditText.SetHintTextColor(Color.Gray);
            nameEditText.SetHintTextColor(Color.Gray);
            emailEditText.SetHintTextColor(Color.Gray);
        }
    }
}