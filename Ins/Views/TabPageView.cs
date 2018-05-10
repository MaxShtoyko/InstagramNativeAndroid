using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using Ins.Core.ViewModels;
using Ins.Droid.Services;
using MvvmCross.Droid.Views;
using static Android.Widget.TabHost;

namespace Ins.Droid.Views
{
    [Activity(Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen")]
    public class TabPageView : MvxTabsFragmentActivity
    {
        public TabPageViewModel TabbedViewModel
        {
            get { return (TabPageViewModel)base.ViewModel; }
        }

        public TabPageView()
            : base(Resource.Layout.TabView, Resource.Id.actualtabcontent)
        {
            ActivityHelper.TabPageActivity = this;
        }

        protected override void AddTabs(Bundle args)
        {
            TabHost tabHost = FindViewById<TabHost>(Android.Resource.Id.TabHost);

            TabSpec tab1 = tabHost.NewTabSpec("First Tab");
            TabSpec tab2 = tabHost.NewTabSpec("Second Tab");
            TabSpec tab3 = tabHost.NewTabSpec("Third Tab");

            tab1.SetIndicator("", GetDrawable(Resource.Drawable.cameraIcon));
            tab2.SetIndicator("", GetDrawable(Resource.Drawable.homeIcon));
            tab3.SetIndicator("", GetDrawable(Resource.Drawable.profileIcon));

            tab1.SetContent(new Android.Content.Intent(this, typeof(CameraView)));
            tab2.SetContent(new Android.Content.Intent(this, typeof(NewsView)));
            tab3.SetContent(new Android.Content.Intent(this, typeof(ProfileView)));

            AddTab<CameraView>(args ,TabbedViewModel.CameraVM, tab1);
            AddTab<NewsView>(args, TabbedViewModel.NewsVM, tab2);
            AddTab<ProfileView>(args, TabbedViewModel.ProfileVM, tab3);
        }

    }
}