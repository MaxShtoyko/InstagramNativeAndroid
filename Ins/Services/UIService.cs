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
using Ins.Droid.Views;
using Java.IO;
using MvvmCross.Droid.Views;
using Xamarin.Auth;

namespace Ins.Droid.Services
{
    [Activity(Label = "UIService")]
    public class UIService : IUIService
    {
        public void DismissUI()
        {
            
        }

        public void GoToLoginUI()
        {
            TabPageView.Instance.Finish();
        }

        public object GetCameraUI()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            CameraHelper.file = new File(CameraHelper.directory, String.Format("myPhoto_{0}.jpg", Guid.NewGuid()));
            intent.PutExtra(MediaStore.ExtraOutput, Android.Net.Uri.FromFile(CameraHelper.file));

            return intent;
        }

        public object GetUI(OAuth2Authenticator auth)
        {
            return auth.GetUI(LoginPageView.Instance);
        }

        public void ShowCameraUI(object ui)
        {
            CameraView.Instance.StartActivityForResult(ui as Intent, 0);
        }

        public void ShowUI(object ui)
        {
            LoginPageView.Instance.StartActivity(ui as Intent);
        }
    }
}