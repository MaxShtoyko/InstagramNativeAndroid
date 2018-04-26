using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Ins.Core.Models;
using Ins.Core.ViewModels;
using Ins.Droid.Helpers.CameraHelpers;
using Ins.Droid.Services;
using MvvmCross.Droid.Views.Fragments;
using Xamarin.Facebook.Login.Widget;

namespace Ins.Droid.Views
{
    [Activity(Label = "NewsView", Theme = "@style/Theme.AppCompat.Light.DarkActionBar")]
    public class NewsView : MvxFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container,
                                          Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            Typeface robotoLightFont = Typeface.CreateFromAsset(Context.Assets, "fonts/Roboto-Light.ttf");

            var photoAlbum = PhotoAlbum.GetPhotoAlbum();
            // Set our view from the "main" layout resource        

            var view = inflater.Inflate(Resource.Layout.NewsFragmentView, container, false);
            var photoCard = inflater.Inflate(Resource.Layout.PhotoCard, container, false);

            var recyclerView = view.FindViewById(Resource.Id.recyclerView) as RecyclerView;

            var layoutManager = new LinearLayoutManager(Context);
            var adapter = new PhotoAlbumAdapter(photoAlbum);

            recyclerView.SetLayoutManager(layoutManager);          
            recyclerView.SetAdapter(adapter);


            return view;
        }
    }
}