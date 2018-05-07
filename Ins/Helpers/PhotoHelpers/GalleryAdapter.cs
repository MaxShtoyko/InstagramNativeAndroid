﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Ins.Core.Models;
using Ins.Droid.Helpers.CameraHelpers;
using Ins.Droid.Services;

namespace Ins.Droid.Helpers.PhotoHelpers
{
    public class GalleryAdapter : RecyclerView.Adapter
    {
        private PhotoAlbum _photoAlbum;

        public GalleryAdapter(PhotoAlbum photoAlbum)
        {
            _photoAlbum = photoAlbum;
        }

        public override int ItemCount
        {
            get => _photoAlbum.Photos.Count;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            int width = Resources.System.DisplayMetrics.WidthPixels;

            GalleryViewHolder viewHolder = holder as GalleryViewHolder;
            Bitmap bitmap = BitmapHelpers.LoadAndResizeBitmap(_photoAlbum.Photos[position].Path, width, width/4);

            viewHolder.image.SetImageBitmap(bitmap);
        }
        
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.GalleryCard, parent, false);       
            GalleryViewHolder viewHolder = new GalleryViewHolder(itemView, null);

            return viewHolder;
        }
    }
}