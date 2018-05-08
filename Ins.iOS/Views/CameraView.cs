using System;
using Ins.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using UIKit;

namespace Ins.iOS.Views
{
    public partial class CameraView : BaseView
    {
        public CameraView() : base("CameraView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
			TakePhotoButton.Layer.BorderColor = UIColor.Black.CGColor;
			TakePhotoButton.Layer.BorderWidth = 1;
			TakePhotoButton.Layer.CornerRadius = 4;
        }

		protected override void CreateBindings()
		{
            var set = this.CreateBindingSet<CameraView, CameraViewModel>();

            set.Bind(TakePhotoButton)
               .To(vm => vm.OnTakePhoto);

            set.Apply();
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

