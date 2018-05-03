using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ins.Core.Interfaces;
using Ins.Droid.Views;

namespace Ins.Droid.Services
{
    public class ErrorService:IErrorService
    {
        public void ShowError(string message)
        {
            Toast.MakeText(ActivityHelper.BaseActivity, message, ToastLength.Long).Show();
        }
    }
}