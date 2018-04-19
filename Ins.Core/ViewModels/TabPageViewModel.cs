using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace Ins.Core.ViewModels
{
    public class TabPageViewModel : MvxViewModel
    {
        public TabPageViewModel()
        {
            CameraVM = Mvx.IocConstruct<CameraViewModel>();
            NewsVM = Mvx.IocConstruct<NewsViewModel>();
            ProfileVM = Mvx.IocConstruct<ProfileViewModel>();
        }

        public MvxViewModel CameraVM { get; set; }
        public MvxViewModel NewsVM { get; set; }
        public MvxViewModel ProfileVM { get; set; }
    }
}