using Ins.Core.Interfaces;
using Ins.iOS.Presenters;
using Ins.iOS.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using UIKit;

namespace Ins.iOS
{
    public class Setup : MvxIosSetup
    {
        private UIWindow _window;
        private IMvxApplicationDelegate _applicationDelegate;

        public Setup(IMvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
            _applicationDelegate = applicationDelegate;
            _window = window;
        }
        
        public Setup(IMvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override void InitializeIoC()
        {
            base.InitializeIoC();
            Mvx.RegisterSingleton<IUIService>(() => new UIService());
            Mvx.RegisterSingleton<IErrorService>(() => new ErrorService());
        }

		protected override IMvxIosViewPresenter CreatePresenter()
		{
            var presenter = new MyNavigationPresenter(_applicationDelegate, _window);
            Mvx.RegisterSingleton(presenter);
            return presenter;
		}

		protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}
