using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using Ins.Core;
using MvvmCross.Platform;
using Ins.Core.Interfaces;
using Ins.Droid.Services;

namespace Ins.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();
            Mvx.RegisterSingleton<IUIService>(() => new UIService());
            Mvx.RegisterSingleton<IErrorService>(() => new ErrorService());
            Mvx.RegisterSingleton<ICameraUIService>(() => new CameraUIService());
        }
    }
}
