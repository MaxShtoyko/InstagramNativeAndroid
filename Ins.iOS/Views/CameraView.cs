using System;
using MvvmCross.iOS.Views;

namespace Ins.iOS
{
    public partial class CameraView : MvxViewController
    {
        public CameraView (IntPtr handle) : base (handle)
        {
        }

        public CameraView() : base("CameraView", null)
        {
        }
    }
}