using System;
using Xamarin.Auth;
namespace Ins.Core.Interfaces
{
    public interface IUIService
    {
        object GetUI(OAuth2Authenticator auth);
        object GetCameraUI();

        void ShowUI(object ui);
        void ShowCameraUI(object ui);

        void DismissUI();
    }
}