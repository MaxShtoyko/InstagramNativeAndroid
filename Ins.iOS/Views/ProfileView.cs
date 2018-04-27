using Ins.Core.ViewModels;

using MvvmCross.Binding.BindingContext;

namespace Ins.iOS.Views
{
    public partial class ProfileView : BaseView
    {
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

            set.Apply();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

