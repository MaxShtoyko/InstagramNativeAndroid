using Ins.Core.Interfaces;
using Ins.Core.Models;
using Ins.Droid.Services;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace Ins.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

			Mvx.RegisterType<IDataBaseService<User>, DataBaseService<User>>();
			Mvx.RegisterType<IDataBaseService<Photo>, DataBaseService<Photo>>();

            RegisterNavigationServiceAppStart<ViewModels.LoginPageViewModel>();
        }
    }
}