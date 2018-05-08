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
    public partial class RegistrationPageView : BaseView
    {
		CAGradientLayer gradientLayer;

        public RegistrationPageView() : base("RegistrationPageView", null)
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
            
            EmailTextField.BackgroundColor = InstrugrumColors.BoxBackgroundTransparentColor;
            EmailTextField.TintColor = InstrugrumColors.PlaceholderTextColor;
            EmailTextField.AttributedPlaceholder =
                new NSAttributedString("E-mail", null, InstrugrumColors.PlaceholderTextColor);
            EmailTextField.Layer.BorderWidth = 0;

            FullNameTextField.BackgroundColor = InstrugrumColors.BoxBackgroundTransparentColor;
            FullNameTextField.TintColor = InstrugrumColors.PlaceholderTextColor;
            FullNameTextField.AttributedPlaceholder =
                new NSAttributedString("Full Name", null, InstrugrumColors.PlaceholderTextColor);
            FullNameTextField.Layer.BorderWidth = 0;

            LoginTextField.BackgroundColor = InstrugrumColors.BoxBackgroundTransparentColor;
            LoginTextField.TintColor = InstrugrumColors.PlaceholderTextColor;
            LoginTextField.AttributedPlaceholder =
                new NSAttributedString("Login", null, InstrugrumColors.PlaceholderTextColor);
			LoginTextField.Layer.BorderWidth = 0;

            PasswordTextField.BackgroundColor = InstrugrumColors.BoxBackgroundTransparentColor;
            PasswordTextField.TintColor = InstrugrumColors.PlaceholderTextColor;
            PasswordTextField.AttributedPlaceholder =
                new NSAttributedString("Password", null, InstrugrumColors.PlaceholderTextColor);
            PasswordTextField.Layer.BorderWidth = 0;

            SignUpButton.SetTitleColor(InstrugrumColors.BoxBorderTransparentColor, UIControlState.Normal);
			SignUpButton.Layer.BorderColor = InstrugrumColors.BoxBorderTransparentColor.CGColor;
			SignUpButton.Layer.BorderWidth = 1;
			SignUpButton.Layer.CornerRadius = 4;
            
            SetPadding(EmailTextField, 8);
            SetPadding(FullNameTextField, 8);
            SetPadding(LoginTextField, 8);
            SetPadding(PasswordTextField, 8);
        }

		public static void SetPadding(UITextField f, int padding)
        {
            UIView paddingView = new UIView(new RectangleF(0, 0, padding, 20));
            f.LeftView = paddingView;
            f.LeftViewMode = UITextFieldViewMode.Always;
        }
              
		public override void ViewWillAppear(bool animated)
		{ 
            NavigationController.NavigationBar.BarTintColor = InstrugrumColors.PurpleBackgroundColor;
            NavigationController.NavigationBar.TintColor = UIColor.White;

			base.ViewWillAppear(animated);
		}

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            
            gradientLayer.Frame = View.Frame;
        }

		public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

			NavigationController.NavigationBar.BarTintColor = UINavigationBar.Appearance.BarTintColor;
			NavigationController.NavigationBar.TintColor = UINavigationBar.Appearance.TintColor;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

