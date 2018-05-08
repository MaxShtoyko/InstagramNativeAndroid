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
        }

		public static nfloat GetCellHeight(){
			return (nfloat)360.0;
		}
        

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            CreateBindings();
            
			UserProfileImageView.Layer.MasksToBounds = true;
			UserProfileImageView.Layer.CornerRadius = 10;
        }
    }
}
