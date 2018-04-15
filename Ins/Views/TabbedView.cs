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
using Ins.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Views.Fragments;

namespace Ins.Views
{
    [Activity(Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen")]
    public class TabbedView : MvxTabsFragmentActivity
    {
        public TabbedViewModel TabbedViewModel
        {
            get { return (TabbedViewModel)base.ViewModel; }
        }

        public TabbedView()
            : base(Resource.Layout.TabView, Resource.Id.actualtabcontent)
        {
        }

        protected override void AddTabs(Bundle args)
        {
            AddTab<CameraView>("Camera", "Camera", args, TabbedViewModel.CameraVM);
            AddTab<NewsView>("News", "News", args, TabbedViewModel.NewsVM);
            AddTab<ProfileView>("Profile", "Profile", args, TabbedViewModel.ProfileVM);
            // note that
        }
    }
}