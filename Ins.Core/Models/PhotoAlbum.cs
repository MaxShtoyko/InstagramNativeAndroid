using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ins.Core.Models
{
    public class PhotoAlbum
    {
        private static PhotoAlbum _photoAlbum;

        public ObservableCollection<Photo> Photos { get; set; }

        private PhotoAlbum() { }

        static public PhotoAlbum GetPhotoAlbum()
        {
            if (_photoAlbum == null)
            {
                _photoAlbum = new PhotoAlbum() { Photos = new ObservableCollection<Photo>() };
            }
            return _photoAlbum;
        }

        static public int GetSize()
        {
            return GetPhotoAlbum().Photos.Count;
        }

        static public bool IsEmpty()
        {
            return GetPhotoAlbum().Photos.Count == 0;
        }

    }
}