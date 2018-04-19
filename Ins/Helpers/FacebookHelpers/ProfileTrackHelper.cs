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

namespace Ins.Droid.Helpers.FacebookHelpers
{
    public class ProfileTrackHelper : ProfileTracker
    {
        public event EventHandler<ProfileChangeHelper> mOnProfileChanged;

        protected override void OnCurrentProfileChanged(Profile oldProfile, Profile newProfile)
        {
            if (mOnProfileChanged != null){
                mOnProfileChanged.Invoke(this, new ProfileChangeHelper(newProfile));
            }
        }
    }
}