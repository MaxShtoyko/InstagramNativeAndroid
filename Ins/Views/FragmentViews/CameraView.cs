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
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Views.Fragments;

namespace Ins.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class CameraView: MvxFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                          Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.CameraFragmentView, null);
        }

    }

}