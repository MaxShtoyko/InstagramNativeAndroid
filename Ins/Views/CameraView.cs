using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ins.ViewModels;
using Java.IO;
using MvvmCross.Droid.Views;

namespace Ins.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class CameraView: MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CameraView);
        }      
        
    }
}