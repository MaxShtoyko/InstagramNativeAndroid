 using System;

using Foundation;
using Ins.Core.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace Ins.iOS.Views
{
    public partial class PhotoCell : MvxTableViewCell
    {
        private MvxImageViewLoader _loader;
        private bool _isLoaded;

        public static readonly NSString Key = new NSString("PhotoCell");

        public PhotoCell(IntPtr handle) : base(handle)
        {
        }

        private void CreateBindings()
        {
            var set = this.CreateBindingSet<PhotoCell, Photo>();

            _loader = new MvxImageViewLoader(() => UserProfileImageView);

            //set.Bind(_loader)
              // .To(vm => vm.CurrentUser.PictureUrl);

            set.Bind(AuthorLabel)
               .To(photo => photo.Author);

            set.Bind(DateOfPublicationLabel)
               .To(photo => photo.DateOfPublication);

            set.Apply();

            if (!_isLoaded){
                PhotoImageView.Image = UIImage.FromFile(PictureSelector.GetPicture());
                _isLoaded = true;
            }
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            CreateBindings();
            
            UserProfileImageView.Layer.MasksToBounds = true;
            UserProfileImageView.Layer.CornerRadius = 10;

            PhotoImageView.Layer.MasksToBounds = true;
            ResizePhotoView(PhotoImageView);
            //CenterImage(PhotoImageView);
        }

        private void ResizePhotoView(UIImageView imageView)
        {
            var imageHeight = imageView.Image.Size.Height;
            var imageWidth = imageView.Image.Size.Width;

            double scaleFactor = imageWidth / imageView.Frame.Width;
            var requiredHeight = imageHeight / scaleFactor;

            photoHeightConstraint.Constant = (nfloat) requiredHeight;
        }

        private void CenterImage(UIImageView imageView)
        {
            imageView.ContentMode = UIViewContentMode.Redraw;
        }
    }

    public static class PictureSelector
    {
        static bool Switch { get; set; }

        static readonly string Picture1 = "portrait.jpg";
        static readonly string Picture2 = "Mountain.jpg";

        public static string GetPicture()
        {
            Switch = !Switch;

            if (Switch) return Picture1;
            else return Picture2;
        }
    }
}
