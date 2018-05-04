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

            SetViews(view);

            return view;
        }

        void SetViews(View view)
        {
            Typeface robotoLightFont = Typeface.CreateFromAsset(Context.Assets, "fonts/Roboto-Light.ttf");

            var emailEditText = view.FindViewById<EditText>(Resource.Id.profileEmailEditText);
            var nameEditText = view.FindViewById<EditText>(Resource.Id.profileUserNameEditText);
            var loginEditText = view.FindViewById<EditText>(Resource.Id.profileUserLoginEditText);

            emailEditText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
            nameEditText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
            loginEditText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);

            emailEditText.SetBackgroundResource(Resource.Drawable.LoginEditTextStyle);
            nameEditText.SetBackgroundResource(Resource.Drawable.LoginEditTextStyle);
            loginEditText.SetBackgroundResource(Resource.Drawable.LoginEditTextStyle);

            loginEditText.SetHintTextColor(Color.Black);
            nameEditText.SetHintTextColor(Color.Black);
            emailEditText.SetHintTextColor(Color.Black);
        }
    }
}