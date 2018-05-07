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
using Xamarin.Facebook.Login.Widget;

namespace Ins.Droid.Helpers.CameraHelpers
{
    public class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Author { get; set; }
        public TextView Date { get; set; }
        public ProfilePictureView UserIcon {get;set; }

        public PhotoViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            Author = itemView.FindViewById<TextView>(Resource.Id.authorText);
            Date = itemView.FindViewById<TextView>(Resource.Id.dateText);
            UserIcon = itemView.FindViewById<ProfilePictureView>(Resource.Id.profileImageView);
        }
    }

}