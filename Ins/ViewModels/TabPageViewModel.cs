using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace Ins.Droid.ViewModels
{
    public class TabPageViewModel : MvxViewModel
    {
        public TabPageViewModel()
        {
            CameraVM = Mvx.IocConstruct<CameraViewModel>();
            NewsVM = Mvx.IocConstruct<NewsViewModel>();
            ProfileVM = Mvx.IocConstruct<ProfileViewModel>();
        }

        public MvxViewModel CameraVM { get; set; }
        public MvxViewModel NewsVM { get; set; }
        public MvxViewModel ProfileVM { get; set; }
    }
}