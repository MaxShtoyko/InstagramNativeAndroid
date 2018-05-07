using Android.Content.Res;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Ins.Core.Models;
using Ins.Droid.Services;
using System.Linq;

namespace Ins.Droid.Helpers.CameraHelpers
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
            int width = Resources.System.DisplayMetrics.WidthPixels;
            int height = Resources.System.DisplayMetrics.HeightPixels;

            PhotoViewHolder viewHolder = holder as PhotoViewHolder;
            viewHolder.Image.SetImageBitmap(BitmapHelpers.LoadAndResizeBitmap(_photoAlbum.Photos[position].Path, width, height));
            viewHolder.Date.Text = _photoAlbum.Photos[position].DateOfPublication;
            viewHolder.Author.Text = _photoAlbum.Photos[position].Author;
            viewHolder.UserIcon.ProfileId = UserService.GetUserId();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.PhotoCard, parent, false);
            PhotoViewHolder viewHolder = new PhotoViewHolder(itemView, null);

            TextView authorText = itemView.FindViewById<TextView>(Resource.Id.authorText) as TextView;
            TextView dateText = itemView.FindViewById<TextView>(Resource.Id.dateText) as TextView;

            Typeface robotoLightFont = Typeface.CreateFromAsset(itemView.Context.Assets, "fonts/Roboto-Light.ttf");

            authorText.SetTypeface(robotoLightFont, TypefaceStyle.Bold);
            dateText.SetTypeface(robotoLightFont, TypefaceStyle.Normal);

            return viewHolder;
        }
    }
}