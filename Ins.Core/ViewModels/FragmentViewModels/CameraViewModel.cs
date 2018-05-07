using Ins.Core.Interfaces;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Ins.Core.ViewModels
{
    public class CameraViewModel : MvxViewModel
    {
        private readonly ICameraUIService _cameraUIService;
        private readonly IUserService _userService;

        public ICommand OnTakePhoto { get; private set; }

        private User _currentUser;
        public User CurrentUser
        {
            get => _currentUser;
            set
            {
                if (SetProperty(ref _currentUser, value))
                    RaisePropertyChanged(() => _currentUser);
            }
        }
        public CameraViewModel(ICameraUIService cameraUIService, IUserService userService)
        {
            _cameraUIService = cameraUIService;
            _userService = userService;

            _currentUser = _userService.GetCurrentUser();

            OnTakePhoto = new MvxCommand(TakePhotoClicked);
        }

        void TakePhotoClicked()
        {
            object ui = _cameraUIService.GetCameraUI();
            _cameraUIService.ShowCameraUI(ui);
        }
    }
   
}