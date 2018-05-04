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
    [Register ("NewsView")]
    partial class NewsView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView NewsTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (NewsTableView != null) {
                NewsTableView.Dispose ();
                NewsTableView = null;
            }
        }
    }
}