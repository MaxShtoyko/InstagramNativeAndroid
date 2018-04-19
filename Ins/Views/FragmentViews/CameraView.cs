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
using Ins.Helpers;
using Ins.Models;
using Ins.Services;
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
        private ImageView _imageView;
        private Button _button;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                          Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.CameraFragmentView, container, false);

            CreateDirectoryForPictures();

            _imageView = view.FindViewById(Resource.Id.imageView1) as ImageView;
            _button = view.FindViewById<Button>(Resource.Id.myButton) as Button;

            _button.Click += TakeAPicture;

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
                Picture = CameraHelper.file.Path.LoadAndResizeBitmap(width, height),
                DateOfPublication = DateTime.Now.ToLongDateString(),
                Author = UserService.GetCurrentUserName()
            };

            _imageView.SetImageBitmap(newPhoto.Picture);

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