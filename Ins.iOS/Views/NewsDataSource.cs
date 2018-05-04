using System;
using Foundation;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace Ins.iOS.Views
{
    public class NewsDataSource : MvxTableViewSource
    {
        public NewsDataSource(UITableView tableView) : base(tableView)
        {
        }

        public NewsDataSource(IntPtr handle) : base(handle)
        {
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return ItemsSource.Count();
        }

        public override nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = (PhotoCell)tableView.DequeueReusableCell(PhotoCell.Key);
            return cell;
        }
    }
}
