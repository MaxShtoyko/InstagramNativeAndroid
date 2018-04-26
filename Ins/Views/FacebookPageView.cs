using Android.App;
using Android.Content;
using Android.OS;
using Ins.Core.Interfaces;
using Ins.Core.Models;
using Ins.Droid.Helpers;
using Ins.Droid.Helpers.FacebookHelpers;
using Ins.Droid.Services;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using Newtonsoft.Json;
using System;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Login.Widget;

namespace Ins.Droid.Views
{

    [Activity]
    public class FacebookPageView : MvxActivity, IFacebookCallback, GraphRequest.IGraphJSONObjectCallback
    {
        private ICallbackManager _callBackManager;
        private IUserService _userService;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            FacebookSdk.SdkInitialize( this.ApplicationContext );

            _userService = Mvx.Resolve<IUserService>();
            _callBackManager = CallbackManagerFactory.Create();

            SetLoginButton();

            if (FacebookProfileHelper.IsRegistred()){
                StartActivity(typeof(TabPageView));              
            }

        }

        public void OnCompleted( Org.Json.JSONObject json, GraphResponse response )
        {
            string data = json.ToString();
            FacebookProfile result = JsonConvert.DeserializeObject<FacebookProfile>(data);

            _userService.SetUser(result);

            if (FacebookProfileHelper.IsRegistred()){
                StartActivity(typeof(TabPageView));
            }
        }

        private void SetLoginButton()
        {
            LoginButton button = new LoginButton(this);
            button.SetReadPermissions(ConstantHelper.permissions);
            button.RegisterCallback(_callBackManager, this);

            button.CallOnClick();            
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
            //throw new NotImplementedException();
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (resultCode == Result.Ok){
                base.OnActivityResult(requestCode, resultCode, data);
                _callBackManager.OnActivityResult(requestCode, (int)resultCode, data);
                SendRequest();
            }
            else {
                Finish();
            }
        }
    }  
}