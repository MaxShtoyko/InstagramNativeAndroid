using System;
using Ins.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace Ins.iOS.Views
{
    public partial class RegistrationPageView : BaseView
    {
        public RegistrationPageView() : base("RegistrationPageView", null)
        {
        }

        protected override void CreateBindings()
        {

            var set = this.CreateBindingSet<RegistrationPageView, RegistrationPageViewModel>();

            set.Bind(EmailTextField)
               .To(vm => vm.User.Email)
               .TwoWay();

            set.Bind(FullNameTextField)
               .To(vm => vm.User.FullName)
               .TwoWay();

            set.Bind(LoginTextField)
               .To(vm => vm.User.Login)
               .TwoWay();

            set.Bind(PasswordTextField)
               .To(vm => vm.User.Password)
               .TwoWay();

            set.Bind(SignUpButton)
               .To(vm => vm.OnSignUp);

            set.Apply();
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
    }
}

