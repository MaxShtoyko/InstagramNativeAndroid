using Ins.Core.Interfaces;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Ins.Core.ViewModels
{
    public class CameraViewModel : MvxViewModel
    {
        private IUIService _uiService;

        public ICommand OnTakePhoto { get; private set; }

        public CameraViewModel(IUIService uIService)
        {
            _uiService = uIService;

            OnTakePhoto = new MvxCommand(TakePhotoClicked);
        }

        void TakePhotoClicked()
        {
            object ui = _uiService.GetCameraUI();
            _uiService.ShowCameraUI(ui);
        }
    }
   
}