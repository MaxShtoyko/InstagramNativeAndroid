using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ins.Core.Interfaces;
using Ins.Droid.Helpers;
using Java.IO;

namespace Ins.Droid.Services
{
    public class CameraUIService:ICameraUIService
    {
        public object GetCameraUI()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            CameraHelper.file = new File(CameraHelper.directory, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(CameraHelper.file));

            return intent;
        }

        public void ShowCameraUI(object ui)
        {
            ActivityHelper.CameraPageActivity.StartActivityForResult(ui as Intent, 0);
        }

    }
}