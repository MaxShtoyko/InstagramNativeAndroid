using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using Ins.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace Ins.Droid.Views
{
    [Activity(Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen")]
    public class TabPageView : MvxTabsFragmentActivity
    {
        internal static TabPageView Instance { get; private set; }

        public TabPageViewModel TabbedViewModel
        {
            get { return (TabPageViewModel)base.ViewModel; }
        }

        public TabPageView()
            : base(Resource.Layout.TabView, Resource.Id.actualtabcontent)
        {
            Instance = this;
        }

        protected override void AddTabs(Bundle args)
        {
            AddTab<CameraView>("Camera", "Camera", args, TabbedViewModel.CameraVM);
            AddTab<NewsView>("News", "News", args, TabbedViewModel.NewsVM);
            AddTab<ProfileView>("Profile", "Profile", args, TabbedViewModel.ProfileVM);
        }

    }
}