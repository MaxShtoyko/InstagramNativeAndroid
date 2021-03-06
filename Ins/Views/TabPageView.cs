﻿using Android.App;
using Android.OS;
using Ins.Core.ViewModels;
using MvvmCross.Droid.Views;

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
        }

        protected override void AddTabs(Bundle args)
        {
            AddTab<CameraView>("Camera", "Camera", args, TabbedViewModel.CameraVM);
            AddTab<NewsView>("News", "News", args, TabbedViewModel.NewsVM);
            AddTab<ProfileView>("Profile", "Profile", args, TabbedViewModel.ProfileVM);
        }
    }
}