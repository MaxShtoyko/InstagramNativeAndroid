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
using Android.Widget;

namespace Ins.Droid.Helpers.PhotoHelpers
{
    public class GalleryViewHolder : RecyclerView.ViewHolder
    {
        public ImageView image { get; set; }

        public GalleryViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            image = itemView.FindViewById<ImageView>(Resource.Id.galleryPhotoImageView);
        }
    }
}