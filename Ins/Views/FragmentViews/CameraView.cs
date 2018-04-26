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
using MvvmCross.Droid.Views.Fragments;
using System;

namespace Ins.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class CameraView: MvxFragment
    {
        private ImageView _imageView;
        private Button _takePhotoButton;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                          Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.CameraFragmentView, container, false);

            CreateDirectoryForPictures();

            _imageView = view.FindViewById(Resource.Id.lastPhoto) as ImageView;
            _takePhotoButton = view.FindViewById<Button>(Resource.Id.takePhotoButton) as Button;

            Typeface robotoLightFont = Typeface.CreateFromAsset(Context.Assets, "fonts/Roboto-Light.ttf");
            _takePhotoButton.SetTypeface(robotoLightFont, TypefaceStyle.Normal);

            _takePhotoButton.Click += TakeAPicture;

            if (CameraHelper.file != null){
                SetImage();
            }
       
            return view;                      
        }

        private void CreateDirectoryForPictures()
        {
            CameraHelper.directory = new File(
                Android.OS.Environment.GetExternalStoragePublicDirectory(
                    Android.OS.Environment.DirectoryPictures), "CameraAppDemo");

            if (!CameraHelper.directory.Exists())
            {
                CameraHelper.directory.Mkdirs();
            }
        }

        public override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            // Make it available in the gallery

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

            GC.Collect();
        }

        private void TakeAPicture(object sender, EventArgs eventArgs)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            CameraHelper.file = new File(CameraHelper.directory, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(CameraHelper.file));
            StartActivityForResult(intent, 0);
        }
    }

}