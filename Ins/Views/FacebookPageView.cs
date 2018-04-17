using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ins.Models;
using MvvmCross.Droid.Views;
using Newtonsoft.Json;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Login.Widget;
using Xamarin.Facebook.Share.Model;
using Ins.Services;
using Ins.Helpers;
using Ins.Interfaces;

namespace Ins.Views
{

    [Activity(Label = "FacebookPageView", MainLauncher = true)]
    public class FacebookPageView : MvxActivity, IFacebookCallback, GraphRequest.IGraphJSONObjectCallback
    {
        private ICallbackManager _callBackManager;
        private IUserService _userService;

        public FacebookPageView()
        {
              
        }

        public FacebookPageView( IUserService userService )
        {
            _userService = userService;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView( Resource.Layout.FacebookPage );

            FacebookSdk.SdkInitialize( this.ApplicationContext );
            _callBackManager = CallbackManagerFactory.Create();

            SetLoginButton();

            LoginManager.Instance.RegisterCallback( _callBackManager, this );
        }

        public void OnCompleted( Org.Json.JSONObject json, GraphResponse response )
        {
            string data = json.ToString();
            FacebookProfile result = JsonConvert.DeserializeObject<FacebookProfile>(data);

            if (_userService.GetCurrentUser().ProfilePictureView == null){
                _userService.GetCurrentUser().ProfilePictureView = new ProfilePictureView(this);
            }

            _userService.SetUser(result);
            StartActivity(typeof(TabPageView));
        }

        private void SetLoginButton()
        {
            LoginButton button = FindViewById<LoginButton>(Resource.Id.login_button);
            button.SetReadPermissions(ConstantHelper.permissions);
            button.RegisterCallback(_callBackManager, this);
        }

        private void SendRequest()
        {
            GraphRequest request = GraphRequest.NewMeRequest(AccessToken.CurrentAccessToken, this);

            Bundle parameters = new Bundle();
            parameters.PutString("fields", "id,name,age_range,email");
            request.Parameters = parameters;
            request.ExecuteAsync();
        }

        public void OnCancel()
        {
            //throw new NotImplementedException();
        }


        public void OnError(FacebookException error)
        {
            //throw new NotImplementedException();
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            LoginResult loginResult = result as LoginResult;
            Console.WriteLine(AccessToken.CurrentAccessToken.UserId);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            _callBackManager.OnActivityResult(requestCode, (int)resultCode, data);
            SendRequest();
        }
    }  
}