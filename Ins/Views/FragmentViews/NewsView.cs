using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Ins.Droid.Helpers.CameraHelpers;
using Ins.Droid.Models;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Views.Fragments;

namespace Ins.Droid.Views
{
    [Activity(Label = "NewsView", Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    public class NewsView : MvxFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                          Bundle savedInstanceState)
        {
            var photoAlbum = PhotoAlbum.GetPhotoAlbum();
            // Set our view from the "main" layout resource        

            var view = inflater.Inflate(Resource.Layout.NewsFragmentView, container, false);
            var recyclerView = view.FindViewById(Resource.Id.recyclerView) as RecyclerView;

            var layoutManager = new LinearLayoutManager(Context);
            var adapter = new PhotoAlbumAdapter(photoAlbum);

            recyclerView.SetLayoutManager(layoutManager);          
            recyclerView.SetAdapter(adapter);

            base.OnCreateView(inflater, container, savedInstanceState);

            return view;
        }

    }
}