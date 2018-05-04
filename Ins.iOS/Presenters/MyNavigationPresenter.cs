﻿using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views.Presenters;
using UIKit;

namespace Ins.iOS.Presenters
{
    public class MyNavigationPresenter : MvxIosViewPresenter 
    {
		public MyNavigationPresenter(IUIApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
        }

        public override void Show(MvxViewModelRequest request)
		{
            if (request.PresentationValues != null)
            {
                if (request.PresentationValues.ContainsKey("NavigationMode") && request.PresentationValues["NavigationMode"] == "ClearStack")
                    MasterNavigationController.PopToRootViewController(false);
            }

            base.Show(request);
		}
	}
}
