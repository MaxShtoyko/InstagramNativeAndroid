using Ins.Core.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace Ins.iOS.Views
{
    public partial class LoginPageView : BaseView
    {
        public LoginPageView() : base("LoginPageView", null)
        {
            Title = "Instrugrum";
        }

        protected override void CreateBindings()
        {
            var set = this.CreateBindingSet<LoginPageView, LoginPageViewModel>();

            set.Bind(EmailTextField)
               .To(vm => vm.User.Email)
               .TwoWay();

            set.Bind(PasswordTextField)
               .To(vm => vm.User.Password)
               .TwoWay();

            set.Bind(LogInButton)
               .To(vm => vm.OnLogIn);

            set.Bind(SignUpButton)
               .To(vm => vm.OnSignUp);

            set.Bind(LoginViaFacebookButton)
               .To(vm => vm.OnLogInViaFacebook);

            set.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.NavigationBar.Hidden = true;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            NavigationController.NavigationBar.Hidden = false;
        }
    }
}

