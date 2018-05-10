using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Ins.Core.Interfaces;
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
        private ImageView _imageView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                          Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            ActivityHelper.CameraPageActivity = this;

            var view = this.BindingInflate(Resource.Layout.CameraFragmentView, null);

            SetViews(view);
            CreateDirectoryForPictures();

            if (!PhotoAlbum.GetPhotoAlbum().IsEmpty()){
                SetImage();
            }

            return view;
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
                AddImageToPhotoAlbum();
                SetImage();
            }
            CameraHelper.file = null;
        }

        void SetViews(View view)
        {
            _imageView = view.FindViewById<ImageView>(Resource.Id.lastPhotoImage);
            var takePhotoButton = view.FindViewById<Button>(Resource.Id.takePhotoButton);
            var sharePhotoTextView = view.FindViewById<TextView>(Resource.Id.sharePhotoTextView);

            Typeface robotoLightFont = Typeface.CreateFromAsset(Context.Assets, "fonts/Roboto-Light.ttf");

            takePhotoButton.SetTypeface(robotoLightFont, TypefaceStyle.Bold);
            sharePhotoTextView.SetTypeface(robotoLightFont, TypefaceStyle.Normal);
        }

        private void AddImageToPhotoAlbum()
        {
            var photoDataBaseService = new DataBaseService<Photo>();

            Photo newPhoto = new Photo()
            {
                Path = CameraHelper.file.Path,
                DateOfPublication = DateTime.Now.ToLongDateString(),
                Author = UserService.GetCurrentUserName()
            };

            photoDataBaseService.InsertIntoTable(newPhoto);

            PhotoService.AddPhoto(newPhoto);
        }

        private void SetImage()
        {
            int width = Resources.DisplayMetrics.WidthPixels;
            int height = Resources.DisplayMetrics.HeightPixels;

            var photo = PhotoService.GetLastPhoto();
            
            Bitmap bitmap = BitmapHelpers.LoadAndResizeBitmap(photo.Path,width, height);

            _imageView.SetImageBitmap(bitmap);
        }
    }

}