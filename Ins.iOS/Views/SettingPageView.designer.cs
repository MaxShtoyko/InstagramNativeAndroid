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
    [Register ("SettingPageView")]
    partial class SettingPageView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField EmailTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField FullNameTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField LoginTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton LogOutButton { get; set; }

		[Outlet]
        [GeneratedCode("iOS Designer", "1.0")]
        UIKit.UIButton SaveChangesButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (EmailTextField != null) {
                EmailTextField.Dispose ();
                EmailTextField = null;
            }

            if (FullNameTextField != null) {
                FullNameTextField.Dispose ();
                FullNameTextField = null;
            }

            if (LoginTextField != null) {
                LoginTextField.Dispose ();
                LoginTextField = null;
            }

            if (LogOutButton != null) {
                LogOutButton.Dispose ();
                LogOutButton = null;
            }
        }
    }
}