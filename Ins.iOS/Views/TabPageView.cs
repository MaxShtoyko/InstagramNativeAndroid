using System;
using Ins.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;

namespace Ins.iOS.Views
{
    public partial class TabPageView : MvxTabBarViewController<TabPageViewModel>
    {
        private int _tabsCreatedSoFar;
        private bool _constructed;

        public TabPageView() : base()
        {
            _constructed = true;

            // need this additional call to ViewDidLoad because UIkit creates the view before the C# hierarchy has been constructed
            ViewDidLoad();
        }

        public override void ViewDidLoad()
        {
            if (!_constructed)
                return;

            base.ViewDidLoad();

            NavigationItem.HidesBackButton = true;

            CreateTabs();
        }

        public override void ItemSelected(UITabBar tabbar, UITabBarItem item)
        {
            Title = item.Title;
        }

        private void CreateTabs()
        {
            var viewControllers = new UIViewController[]
            {
                CreateTab("Camera", "CameraTab-", (ViewModel as TabPageViewModel).CameraVM),
                CreateTab("News", "HomeTab-", (ViewModel as TabPageViewModel).NewsVM),
                CreateTab("Profile", "UserTab-", (ViewModel as TabPageViewModel).ProfileVM)
            };

            ViewControllers = viewControllers;

            SelectedViewController = ViewControllers[1];
            Title = SelectedViewController.Title;

            NavigationItem.Title = SelectedViewController.Title;

            ViewControllerSelected += (o, e) =>
            {
                NavigationItem.Title = TabBar.SelectedItem.Title;
            };
        }

        private UIViewController CreateTab(string title, string imageName, IMvxViewModel viewModel)
        {
            var viewController = this.CreateViewControllerFor(viewModel) as UIViewController;
            viewModel.Start();

            UpdateTabBar(viewController, title, imageName);

            return viewController;
        }

		private void UpdateTabBar(UIViewController viewController, string title, string imageName)
		{
			viewController.Title = title;

			viewController.TabBarItem = new UITabBarItem(
				title,
				UIImage.FromBundle(imageName + "normal").
				    ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal),
				_tabsCreatedSoFar)
			{
				SelectedImage = UIImage.FromBundle(imageName + "active")
									   .ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal)
		    };

            viewController.TabBarItem.ImageInsets = new UIEdgeInsets( 6, 0, -6, 0);
         
            viewController.TabBarItem.SetTitleTextAttributes( 
			         new UITextAttributes { TextColor = UIColor.Clear },
                     UIControlState.Normal);
                         
            _tabsCreatedSoFar++;
        }
    }
}