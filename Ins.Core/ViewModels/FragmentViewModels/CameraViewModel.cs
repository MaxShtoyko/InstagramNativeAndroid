using Ins.Core.Interfaces;
using Ins.Core.Models;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Ins.Core.ViewModels
{
    public class CameraViewModel : MvxViewModel
    {
        private readonly ICameraUIService _cameraUIService;
        private readonly IUserService _userService;
        private readonly IDataBaseService<Photo> _photoDataBaseService;

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
        public CameraViewModel(ICameraUIService cameraUIService, IUserService userService, IDataBaseService<Photo> photoDataBaseService)
        {
            _cameraUIService = cameraUIService;
            _userService = userService;
            _photoDataBaseService = photoDataBaseService;

            _photoDataBaseService.CreateDataBase();
            _currentUser = _userService.GetCurrentUser();

            var photos = _photoDataBaseService.GetItems();
            PhotoAlbum.GetPhotoAlbum().AddPhotos(photos);

            OnTakePhoto = new MvxCommand(TakePhotoClicked);
        }

        void TakePhotoClicked()
        {
            object ui = _cameraUIService.GetCameraUI();
            _cameraUIService.ShowCameraUI(ui);
        }

    }
   
}