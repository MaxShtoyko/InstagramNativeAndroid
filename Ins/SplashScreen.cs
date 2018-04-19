using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace Ins.Droid
{
    [Activity(
        Label = "Ins"
        , MainLauncher = true
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}
