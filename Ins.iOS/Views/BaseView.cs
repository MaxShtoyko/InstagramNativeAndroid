 using System;
using Foundation;
using MvvmCross.iOS.Views;
using UIKit;

namespace Ins.iOS.Views
{
    public class BaseView : MvxViewController
    {
        public BaseView(string nibName, NSBundle bundle) : base(nibName, bundle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            CreateBindings();
        }

		public override UIStatusBarStyle PreferredStatusBarStyle()
        {
            return UIStatusBarStyle.Default;
        }

        protected virtual void CreateBindings()
        {
        }
	}
}
