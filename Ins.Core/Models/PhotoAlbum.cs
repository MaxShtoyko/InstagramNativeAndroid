using System.Collections.Generic;

namespace Ins.Core.Models
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