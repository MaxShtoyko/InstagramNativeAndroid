using System.Linq;
using Ins.Core.Interfaces;
using UIKit;

namespace Ins.iOS.Services
{
    public class ErrorService : IErrorService
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

        public void ShowError(string message)
        {
            {
                var alert = UIAlertController.Create("Alert", message, UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, Dismiss));
                ViewController.PresentViewController(alert, true, null);
            };

            void Dismiss(UIAlertAction alerAction)
            {
                ViewController.DismissModalViewController(true);
            }
        }
    }
}
