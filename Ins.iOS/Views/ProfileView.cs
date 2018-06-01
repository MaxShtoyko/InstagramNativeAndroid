using System;
using Ins.Core.ViewModels;

using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace Ins.iOS.Views
{
	public partial class ProfileView : BaseView
    {
        private MvxImageViewLoader _loader;
        private UIBarButtonItem _settingsButton;

        public ProfileView() : base("ProfileView", null)
        {
        }

        protected override void CreateBindings()
        {
            var set = this.CreateBindingSet<ProfileView, ProfileViewModel>();
            
            set.Bind(FullNameLabel)
               .To(vm => vm.CurrentUser.FullName)
               .TwoWay();

            set.Bind(EmailLabel)
               .To(vm => vm.CurrentUser.Email)
               .TwoWay();

            set.Bind(SettingsButton)
               .To(vm => vm.OnEditProfile);

            _loader = new MvxImageViewLoader(() => ProfilePictureImageView);

            set.Bind(_loader)
               .To(vm => vm.CurrentUser.PictureUrl);

            set.Apply();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if ((ViewModel as ProfileViewModel).CurrentUser.Login != null){
                TabBarItem.Title = (ViewModel as ProfileViewModel).CurrentUser.Login;
            }         
            
            _settingsButton = new UIBarButtonItem(UIImage.FromBundle("SettingsIcon").
                                                           ImageWithRenderingMode(UIImageRenderingMode.AlwaysOriginal),
                                                   UIBarButtonItemStyle.Plain,
                                                   null);

            ProfilePictureImageView.Layer.MasksToBounds = true;
            ProfilePictureImageView.Layer.CornerRadius = ProfilePictureImageView.Frame.Size.Width / (nfloat)2.0;

            SettingsButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
            SettingsButton.Layer.CornerRadius = 4;         
        }

        public override void ViewWillAppear(bool animated)
        {
            TabBarController.NavigationItem.SetRightBarButtonItem(_settingsButton, false);

            base.ViewWillAppear(animated);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewWillDisappear(bool animated)
        {
            TabBarController.NavigationItem.SetRightBarButtonItem(null, false);

            base.ViewWillDisappear(animated);
        }
    }
}

