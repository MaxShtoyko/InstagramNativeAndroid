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
using Xamarin.Facebook;

namespace Ins.Helpers.FacebookHelpers
{
    class FacebookProfileHelper
    {
        public static bool IsRegistred()
        {
            return AccessToken.CurrentAccessToken != null;
        }
    }
}