using System;
using System.Drawing;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using Ins.Core.ViewModels;
using Ins.iOS.Utility;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace Ins.iOS.Views
{
    public partial class LoginPageView : BaseView
    {
        CAGradientLayer gradientLayer;

        public LoginPageView() : base("LoginPageView", null)
        {         
            gradientLayer = new CAGradientLayer();
            var leftColor = UIColor.FromRGB(166, 44, 116).CGColor;
            var rightColor = UIColor.FromRGB(134, 60, 145).CGColor;
            gradientLayer.Colors = new[] { leftColor, rightColor };

            gradientLayer.StartPoint = new CGPoint(0, 0.5);
            gradientLayer.EndPoint = new CGPoint(1, 0.5);

            View.Layer.InsertSublayer(gradientLayer, 0);
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

			EmailTextField.BackgroundColor = InstrugrumColors.BoxBackgroundTransparentColor;
			EmailTextField.TintColor = InstrugrumColors.PlaceholderTextColor;
			EmailTextField.AttributedPlaceholder = 
				new NSAttributedString( "E-mail", null, InstrugrumColors.PlaceholderTextColor );
            EmailTextField.Layer.BorderWidth = 0;

			PasswordTextField.BackgroundColor = InstrugrumColors.BoxBackgroundTransparentColor;
			PasswordTextField.TintColor = InstrugrumColors.PlaceholderTextColor;
			PasswordTextField.AttributedPlaceholder = 
				new NSAttributedString( "Password", null, InstrugrumColors.PlaceholderTextColor );
			PasswordTextField.Layer.BorderWidth = 0;

            LogInButton.SetTitleColor( InstrugrumColors.BoxBorderTransparentColor, UIControlState.Normal);
            LogInButton.Layer.BorderColor = InstrugrumColors.BoxBorderTransparentColor.CGColor;
            LogInButton.Layer.BorderWidth = 1;
            LogInButton.Layer.CornerRadius = 4;

			SignUpButton.BackgroundColor = InstrugrumColors.BoxBackgroundTransparentColor;

			LeftSplitterView.BackgroundColor = InstrugrumColors.SplitterColor;
			RightSplitterView.BackgroundColor = InstrugrumColors.SplitterColor;
			OrLabel.TextColor = InstrugrumColors.SplitterColor;

			SetPadding(EmailTextField, 8);
			SetPadding(PasswordTextField, 8);
            
			LoginViaFacebookButton.TintColor = UIColor.White;
        }

		public static void SetPadding(UITextField f, int padding)
        {
            UIView paddingView = new UIView(new RectangleF(0, 0, padding, 20));
            f.LeftView = paddingView;
            f.LeftViewMode = UITextFieldViewMode.Always;
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            gradientLayer.Frame = View.Frame;
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

