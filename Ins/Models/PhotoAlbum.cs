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

namespace Ins.Models
{
    public class PhotoAlbum
    {
        private static PhotoAlbum _photoAlbum;

        public List<Photo> Photos { get; set; }

        private PhotoAlbum() { }

        static public PhotoAlbum GetPhotoAlbum()
        {
            if(_photoAlbum == null){
                _photoAlbum = new PhotoAlbum(){ Photos = new List<Photo>() };
            }
            return _photoAlbum;
        }
    }
}