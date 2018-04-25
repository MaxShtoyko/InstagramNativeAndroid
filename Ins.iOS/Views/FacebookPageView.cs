using Ins.Core.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace Ins.iOS.Views
{
    public partial class FacebookPageView : BaseView
    {
        public FacebookPageView() : base("FacebookPageView", null)
        {
        }

        protected override void CreateBindings()
        {
            var set = this.CreateBindingSet<FacebookPageView, FacebookPageViewModel>();

            set.Apply();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

