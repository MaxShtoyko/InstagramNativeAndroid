using System;
using System.Collections.Generic;
using System.Text;

namespace Ins.Core.Interfaces
{
    public interface ICameraUIService
    {
        object GetCameraUI();
        void ShowCameraUI(object ui);
    }
}
