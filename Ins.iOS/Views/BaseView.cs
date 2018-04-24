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

            var stringAttributes = new UIStringAttributes();
            stringAttributes.Font = UIFont.SystemFontOfSize(18);
            stringAttributes.ForegroundColor = UIColor.Black;
            NavigationController.NavigationBar.TitleTextAttributes = stringAttributes;

            NavigationController.NavigationBar.BackgroundColor = UIColor.White;

            if (RespondsToSelector(new ObjCRuntime.Selector("edgesForExtendedLayout")))
            {
                EdgesForExtendedLayout = UIRectEdge.None;
            }

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
