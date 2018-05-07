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
using Ins.Droid.Views;

namespace Ins.Droid.Services
{
    class ActivityHelper
    {
        internal static BaseMvxView BaseActivity { get; set; }
        internal static TabPageView TabPageActivity { get; set; }
        internal static CameraView CameraPageActivity { get; set; }   
    }
}