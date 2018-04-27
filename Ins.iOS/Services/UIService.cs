using System;
using System.Linq;
using Ins.Core.Interfaces;
using UIKit;
using Xamarin.Auth;

namespace Ins.iOS.Services
{
    public class UIService : IUIService
    {
        public void DismissUI()
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
                vc = vc.PresentedViewController;

            var navController = vc as UINavigationController;
            if (navController != null)
                vc = navController.ViewControllers.Last();

            vc.DismissViewController(true, null);
        }

        public object GetUI(OAuth2Authenticator auth)
        {
            return auth.GetUI();
        }

        public void ShowUI(object ui)
        {
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            while (vc.PresentedViewController != null)
                vc = vc.PresentedViewController;

            var navController = vc as UINavigationController;
            if (navController != null)
                vc = navController.ViewControllers.Last();

            vc.PresentViewController(ui as UIViewController, true, null);
        }
    }
}
