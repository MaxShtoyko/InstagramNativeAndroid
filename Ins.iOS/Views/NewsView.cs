using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using System;
using UIKit;

namespace Ins.iOS
{
    public partial class NewsView : MvxViewController
    {
        public NewsView (IntPtr handle) : base (handle)
        {
        }

        public NewsView() : base("NewsView", null)
        {
        }
    }
}