using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Ins.Models;
using Android.Widget;

namespace Ins.Helpers.CameraHelpers
{
    public class PhotoAlbumAdapter : RecyclerView.Adapter
    {
        private PhotoAlbum _photoAlbum;

        public PhotoAlbumAdapter(PhotoAlbum photoAlbum)
        {
            _photoAlbum = photoAlbum;
        }

        public override int ItemCount
        {
            get => _photoAlbum.Photos.Count;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder viewHolder = holder as PhotoViewHolder;
            viewHolder.Image.SetImageBitmap(_photoAlbum.Photos[position].Picture);
            viewHolder.Date.Text = _photoAlbum.Photos[position].DateOfPublication;
            viewHolder.Author.Text = _photoAlbum.Photos[position].Author;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PhotoCard, parent, false);
            PhotoViewHolder viewHolder = new PhotoViewHolder(itemView, null);

            return viewHolder;
        }
    }
}