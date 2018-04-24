using Ins.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace Ins.iOS.Views
{
    public partial class LoginPageView : MvxViewController
    {
        protected LoginPageViewModel LoginPageViewModel
            => ViewModel as LoginPageViewModel;

        public LoginPageView() : base("LoginPageView", null)
        {
        }

        protected void CreateBindings(){
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

            set.Bind(ErrorTextLabel).To(vm => vm.Error);

            set.Bind(LoginViaFacebookButton)
               .To(vm => vm.OnLogInViaFacebook);

            set.Apply();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var stringAttributes = new UIStringAttributes();
            stringAttributes.Font = UIFont.SystemFontOfSize(16);
            stringAttributes.ForegroundColor = UIColor.Black;
            //NavigationController.NavigationBar.BarTintColor = new UIColor(6 / 255f, 116 / 255f, 173 / 255f, 1);
            NavigationController.NavigationBar.TintColor = UIColor.White;
            NavigationController.NavigationBar.TitleTextAttributes = stringAttributes;

            this.Title = "Instagram";

            CreateBindings();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

