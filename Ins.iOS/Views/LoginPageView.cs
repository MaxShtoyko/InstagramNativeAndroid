using Ins.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;

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
               .To(vm => vm.User.Email).TwoWay();

            set.Bind(PasswordTextField)
               .To(vm => vm.User.Password).TwoWay();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
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

