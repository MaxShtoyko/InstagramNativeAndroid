using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Ins.Core.Models;
using Ins.Droid.Helpers.CameraHelpers;
using Ins.Droid.Helpers.PhotoHelpers;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Views.Fragments;

namespace Ins.Droid.Views
{
    [Activity(Label = "Profile")]
    public class ProfileView : MvxFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                          Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.ProfileFragmentView, null);
            var galleryCard = inflater.Inflate(Resource.Layout.GalleryCard, container, false);

            var photoAlbum = PhotoAlbum.GetPhotoAlbum();
            var recyclerView = view.FindViewById(Resource.Id.galleryRecyclerView) as RecyclerView;

            var layoutManager = new GridLayoutManager(Context, 3);
            var adapter = new GalleryAdapter(photoAlbum);

            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(adapter);

            SetFonts(view);

            return view;
        }

        void SetFonts(View view)
        {
            Typeface robotoLightFont = Typeface.CreateFromAsset(Context.Assets, "fonts/Roboto-Light.ttf");

            var profileName = view.FindViewById<TextView>(Resource.Id.profileName);
            var profileInformation = view.FindViewById<TextView>(Resource.Id.profileInformation);
            

            profileName.SetTypeface(robotoLightFont, TypefaceStyle.Bold);
            profileInformation.SetTypeface(robotoLightFont, TypefaceStyle.Bold);
        }
    }
}