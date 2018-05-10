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

        public int GetSize()
        {
            return Photos.Count;
        }

        public bool IsEmpty()
        {
            return Photos.Count == 0;
        }

        public void AddPhotos(IEnumerable<Photo> photos)
        {
            foreach(var photo in photos)
            {
                Photos.Add(photo);
            }
        }

    }
}