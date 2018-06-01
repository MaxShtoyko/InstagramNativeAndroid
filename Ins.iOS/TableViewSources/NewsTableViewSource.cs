using System;
using Foundation;
using Ins.iOS.Views;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace Ins.iOS.TableViewSources
{
    public class NewsTableViewSource : MvxTableViewSource
    {
        public NewsTableViewSource(UITableView tableView) : base(tableView)
        {
			tableView.RegisterNibForCellReuse(UINib.FromName("PhotoCell", NSBundle.MainBundle),
			                                  PhotoCell.Key);
        }

        public NewsTableViewSource(IntPtr handle) : base(handle)
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
        
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			return (nfloat)120.0;
		}

		protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            var cell = (PhotoCell)tableView.DequeueReusableCell(PhotoCell.Key);
            return cell;
        }
    }
}
