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
    [Register ("LoginPageView")]
    partial class LoginPageView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EmailTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView LeftSplitterView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LogInButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LoginViaFacebookButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView LogoImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel OrLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PasswordTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView RightSplitterView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SignUpButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (EmailTextField != null) {
                EmailTextField.Dispose ();
                EmailTextField = null;
            }

            if (LeftSplitterView != null) {
                LeftSplitterView.Dispose ();
                LeftSplitterView = null;
            }

            if (LogInButton != null) {
                LogInButton.Dispose ();
                LogInButton = null;
            }

            if (LoginViaFacebookButton != null) {
                LoginViaFacebookButton.Dispose ();
                LoginViaFacebookButton = null;
            }

            if (LogoImageView != null) {
                LogoImageView.Dispose ();
                LogoImageView = null;
            }

            if (OrLabel != null) {
                OrLabel.Dispose ();
                OrLabel = null;
            }

            if (PasswordTextField != null) {
                PasswordTextField.Dispose ();
                PasswordTextField = null;
            }

            if (RightSplitterView != null) {
                RightSplitterView.Dispose ();
                RightSplitterView = null;
            }

            if (SignUpButton != null) {
                SignUpButton.Dispose ();
                SignUpButton = null;
            }
        }
    }
}