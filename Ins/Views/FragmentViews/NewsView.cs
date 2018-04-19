using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Ins.Core.Models;
using Ins.Droid.Helpers.CameraHelpers;
using MvvmCross.Droid.Views.Fragments;

namespace Ins.Droid.Views
{
    [Activity(Label = "NewsView", Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    public class NewsView : MvxFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                          Bundle savedInstanceState)
        {
            var photoAlbum = PhotoAlbum.GetPhotoAlbum();
            // Set our view from the "main" layout resource        

            var view = inflater.Inflate(Resource.Layout.NewsFragmentView, container, false);
            var recyclerView = view.FindViewById(Resource.Id.recyclerView) as RecyclerView;

            var layoutManager = new LinearLayoutManager(Context);
            var adapter = new PhotoAlbumAdapter(photoAlbum);

            recyclerView.SetLayoutManager(layoutManager);          
            recyclerView.SetAdapter(adapter);

            base.OnCreateView(inflater, container, savedInstanceState);

            return view;
        }

    }
}