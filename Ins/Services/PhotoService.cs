using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ins.Models;

namespace Ins.Services
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