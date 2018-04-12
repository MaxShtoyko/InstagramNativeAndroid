using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;

namespace Ins.ViewModels
{
    public class CameraViewModel: MvxViewModel
    {

        public string Title = "hello";

        
        public ICommand MyCommand
        {
            get => new MvxCommand(() => TakeAPicture(), () => true);
        }

        private void TakeAPicture()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            Helper.file = new File(Helper.dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(Helper.file));
            //StartActivityForResult(intent, 0);  
        }
    }


    public static class Helper
    {
        public static File file;
        public static File dir;
        public static Bitmap bitmap;
    }

    public static class BitmapHelpers
    {
        public static Bitmap LoadAndResizeBitmap(this string fileName, int width, int height)
        {
            // First we get the the dimensions of the file on disk
            BitmapFactory.Options options = new BitmapFactory.Options { InJustDecodeBounds = true };
            BitmapFactory.DecodeFile(fileName, options);

            // Next we calculate the ratio that we need to resize the image by
            // to fit the requested dimensions.
            int outHeight = options.OutHeight;
            int outWidth = options.OutWidth;
            int inSampleSize = 1;

            if (outHeight > height || outWidth > width)
            {
                inSampleSize = outWidth > outHeight
                                   ? outHeight / height
                                   : outWidth / width;
            }

            // Now we will load the image and have BitmapFactory resize it for us.
            options.InSampleSize = inSampleSize;
            options.InJustDecodeBounds = false;
            Bitmap resizedBitmap = BitmapFactory.DecodeFile(fileName, options);

            return resizedBitmap;
        }
    }
}