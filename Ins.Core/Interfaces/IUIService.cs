using System;
using Xamarin.Auth;
namespace Ins.Core.Interfaces
{
    public interface IUIService
    {
        object GetUI(OAuth2Authenticator auth);
        void ShowUI(object ui);
        void DismissUI();
    }
}