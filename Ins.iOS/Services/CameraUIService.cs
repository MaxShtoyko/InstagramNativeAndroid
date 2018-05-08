using Ins.Core.Interfaces;
using Ins.Core.Models;

namespace Ins.iOS.Services
{
	public class CameraUIService : ICameraUIService
    {      
		public object GetCameraUI()
		{
			return new object();
		}

		public void ShowCameraUI(object ui)
		{
			var photo = new Photo { Author = "Danya", DateOfPublication = "2018" };
            PhotoAlbum.GetPhotoAlbum().Photos.Add(photo);
            return;
		}
	}
}
