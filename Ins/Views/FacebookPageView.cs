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
using Ins.Droid.Models;
using MvvmCross.Droid.Views;
using Newtonsoft.Json;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Facebook.Login.Widget;
using Xamarin.Facebook.Share.Model;
using Ins.Droid.Services;
using Ins.Droid.Helpers;
using Ins.Droid.Interfaces;
using Ins.Droid.Helpers.FacebookHelpers;

namespace Ins.Droid.Views
{

    [Activity]
    public class FacebookPageView : MvxActivity, IFacebookCallback, GraphRequest.IGraphJSONObjectCallback
    {
        private ICallbackManager _callBackManager;
        private IUserService _userService = new UserService();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            FacebookSdk.SdkInitialize( this.ApplicationContext );

            _callBackManager = CallbackManagerFactory.Create();
            SetLoginButton();
         
            LoginManager.Instance.RegisterCallback(_callBackManager, this);
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

            if (FacebookProfileHelper.IsRegistred()){
                SendRequest();
            }
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
            LoginResult loginResult = result as LoginResult;
            Console.WriteLine(AccessToken.CurrentAccessToken.UserId);
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