using System;
using System.Linq;
using Ins.Core.Interfaces;
using UIKit;
using Xamarin.Auth;

namespace Ins.iOS.Services
{
    public class UIService : IUIService
    {
        UIViewController ViewController
        {
            get
            { 
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;
                while (vc.PresentedViewController != null)
                    vc = vc.PresentedViewController;

                var navController = vc as UINavigationController;
                vc = navController?.ViewControllers.Last();

                return vc;
            } 
        }

        public object GetUI(OAuth2Authenticator auth)
        {
            return auth.GetUI();
        }

        public void ShowUI(object ui)
        {
            ViewController.PresentViewController(ui as UIViewController, true, null);
        }

        public void DismissUI()
        {
            ViewController.DismissViewController(true, null);
        }

        public void GoToLoginUI()
        {
            throw new NotImplementedException();
        }

        public object GetCameraUI()
        {
            throw new NotImplementedException();
        }

        public void ShowCameraUI(object ui)
        {
            throw new NotImplementedException();
        }
    }
}
