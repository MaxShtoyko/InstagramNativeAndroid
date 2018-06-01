using Ins.Core.ViewModels;

using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;

namespace Ins.iOS.Views
{
    public partial class SettingPageView : BaseView
    {
		public SettingPageView() : base("SettingPageView", null)
        {
            Title = "Settings";
        }

        protected override void CreateBindings()
        {
            var set = this.CreateBindingSet<SettingPageView, SettingPageViewModel>();

            set.Bind(EmailTextField)
               .To(ViewModel => ViewModel.CurrentUser.Email)
               .TwoWay();

            set.Bind(FullNameTextField)
               .To(ViewModel => ViewModel.CurrentUser.FullName)
               .TwoWay();

            set.Bind(LoginTextField)
               .To(ViewModel => ViewModel.CurrentUser.Login)
               .TwoWay();

			set.Bind(SaveChangesButton)
			   .To(ViewModel => ViewModel.OnSaveChanges);
			
            set.Bind(LogOutButton)
               .To(ViewModel => ViewModel.OnLogOut);

            set.Apply();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            EmailTextField.Enabled = false;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

