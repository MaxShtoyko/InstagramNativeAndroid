
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;

namespace Ins.Droid.Views
{
    [Activity(Label = "LoginPageView",Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen", MainLauncher = true)]
    public class LoginPageView : BaseMvxView
    {
        internal static LoginPageView Instance { get; private set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Instance = this;

            SetContentView(Resource.Layout.LoginPage);

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
            var header = FindViewById<TextView>(Resource.Id.headerView);
            var emailEntry = FindViewById<EditText>(Resource.Id.emailEntry);
            var passwordEntry = FindViewById<EditText>(Resource.Id.passwordEntry);
            var loginView = FindViewById<RelativeLayout>(Resource.Id.loginView);
            var signUpButton = FindViewById<Button>(Resource.Id.signUpButton);
            var logInButton = FindViewById<Button>(Resource.Id.logInButton);
            var logInViaFacebookButton = FindViewById<Button>(Resource.Id.logInViaFacebookButton);
            var errorText = FindViewById<TextView>(Resource.Id.errorText);

            Typeface headerFont = Typeface.CreateFromAsset(Assets, "fonts/9424.ttf");
            Typeface robotoLightFont = Typeface.CreateFromAsset(Assets, "fonts/Roboto-Light.ttf");

            header.SetTypeface(headerFont, TypefaceStyle.Normal);
            emailEntry.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
            passwordEntry.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
            signUpButton.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
            errorText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);

            passwordEntry.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            emailEntry.SetBackgroundResource(Resource.Drawable.EditTextStyle);
            loginView.SetBackgroundResource(Resource.Drawable.LoginPageStyle);
            logInButton.SetBackgroundResource(Resource.Drawable.ButtonStyle);
            logInViaFacebookButton.SetBackgroundResource(Resource.Drawable.FacebookButtonStyle);
        }
    }
}