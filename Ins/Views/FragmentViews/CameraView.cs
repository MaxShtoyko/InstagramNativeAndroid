using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Views;
using Android.Widget;
using Ins.Core.Models;
using Ins.Core.Services;
using Ins.Droid.Helpers;
using Ins.Droid.Services;
using Java.IO;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Views.Fragments;
using System;

namespace Ins.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class CameraView: MvxFragment
    {
        internal static CameraView Instance { get; private set; }

        private ImageView _imageView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                          Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.CameraFragmentView, container, false);
            var takePhotoButton = view.FindViewById<Button>(Resource.Id.takePhoto) as Button;
            _imageView = view.FindViewById(Resource.Id.lastPhoto) as ImageView;

            CreateDirectoryForPictures();
            Instance = this;

            Typeface robotoLightFont = Typeface.CreateFromAsset(Context.Assets, "fonts/Roboto-Light.ttf");
            takePhotoButton.SetTypeface(robotoLightFont, TypefaceStyle.Normal);

            if (CameraHelper.file != null){
                SetImage();
            }

            return this.BindingInflate(Resource.Layout.CameraFragmentView, null);
        }

        private void CreateDirectoryForPictures()
        {
            CameraHelper.directory = new File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "CameraAppDemo");

            if (!CameraHelper.directory.Exists()){
                CameraHelper.directory.Mkdirs();
            }
        }

        public override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok){
                SetImage();
            }
            CameraHelper.file = null;
        }

        private void SetImage()
        {
            int width = Resources.DisplayMetrics.WidthPixels;
            int height = Resources.DisplayMetrics.HeightPixels;

            Photo newPhoto = new Photo()
            {
                Path = CameraHelper.file.Path,
                DateOfPublication = DateTime.Now.ToLongDateString(),
                Author = UserService.GetCurrentUserName()
            };

            _imageView.SetImageBitmap(BitmapHelpers.LoadAndResizeBitmap(CameraHelper.file.Path, width, height));

            PhotoService.AddPhoto(newPhoto);
        }
    }

}