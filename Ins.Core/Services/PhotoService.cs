using Ins.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ins.Core.Services
{
    public class PhotoService
    {
        static private PhotoAlbum _photoAlbum = PhotoAlbum.GetPhotoAlbum();

        static public List<Photo> GetPhotos()
        {
            return _photoAlbum.Photos;
        }

        static public void AddPhoto(Photo photo)
        {
            _photoAlbum.Photos.Add(photo);
        }
    }
}
