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
        public static readonly NSString Key = new NSString("PhotoCell");
        public static readonly UINib Nib;

        public PhotoCell(IntPtr handle) : base(handle)
        {
        }

        private void CreateBindings()
        {
            var set = this.CreateBindingSet<PhotoCell, Photo>();

            set.Bind(AuthorLabel)
               .To(photo => photo.Author);

            set.Bind(DateOfPublicationLabel)
               .To(photo => photo.DateOfPublication);

            set.Apply();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            CreateBindings();
        }
    }
}
