using Foundation;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace Ins.iOS
{
    public partial class ProfileView : MvxViewController
    {
        public ProfileView (IntPtr handle) : base (handle)
        {
        }

        public ProfileView() : base("ProfileView", null)
        {
        }
    }
}