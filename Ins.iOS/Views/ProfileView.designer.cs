// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Ins.iOS.Views
{
    [Register ("ProfileView")]
    partial class ProfileView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel EmailTextLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FullNameTextLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MvvmCross.Binding.iOS.Views.MvxImageView ProfilePictureImageView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (EmailTextLabel != null) {
                EmailTextLabel.Dispose ();
                EmailTextLabel = null;
            }

            if (FullNameTextLabel != null) {
                FullNameTextLabel.Dispose ();
                FullNameTextLabel = null;
            }

            if (ProfilePictureImageView != null) {
                ProfilePictureImageView.Dispose ();
                ProfilePictureImageView = null;
            }
        }
    }
}