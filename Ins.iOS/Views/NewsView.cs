using System;
using System.Drawing;
using Ins.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace Ins.iOS.Views
{
    public partial class NewsView : BaseView
    {
        private MvxSimpleTableViewSource _newsTableViewSource;

        protected NewsViewModel NewsViewModel => ViewModel as NewsViewModel;

        public NewsView() : base("NewsView", null)
        {
        }

        public override void ViewDidLoad()
        {
            _newsTableViewSource = new MvxSimpleTableViewSource(NewsTableView, PhotoCell.Key, PhotoCell.Key);;

            NewsTableView.Source = _newsTableViewSource;
            NewsTableView.ReloadData();

            base.ViewDidLoad();
        }

        protected override void CreateBindings()
        {
            base.CreateBindings();
            var set = this.CreateBindingSet<NewsView, NewsViewModel>();

            set.Bind(_newsTableViewSource).To(vm => vm.Photos);

            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            //     NewsViewModel.ReloadDataCommand.Execute();

            //savedJourneyTableView.DeselectRow(savedJourneyTableView.IndexPathForSelectedRow, true);
        }
    }
}