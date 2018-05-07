using Ins.Core.ViewModels;

using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace Ins.iOS.Views
{
    public partial class ProfileView : BaseView
    {
        private MvxImageViewLoader _loader;

        public ProfileView() : base("ProfileView", null)
        {
        }

        protected override void CreateBindings()
        {
            var set = this.CreateBindingSet<ProfileView, ProfileViewModel>();

            set.Bind(FullNameTextLabel)
               .To(vm => vm.CurrentUser.FullName)
               .TwoWay();
            
            set.Bind(EmailTextLabel)
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

            var h = UIApplication.SharedApplication.StatusBarFrame.Size.Height;
            ProfileImageViewToTopConstraint.Constant = h + 90;

            var b = View.Frame.Size.Height;
            //SettingsButtopToBottomConstraint.Constant = b - 50;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

