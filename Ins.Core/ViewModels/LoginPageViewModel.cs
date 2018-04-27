using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Ins.Core.Interfaces;
using Ins.Core.Models;
using Ins.Droid.Helpers;
using MvvmCross.Core.ViewModels;
using Newtonsoft.Json;
using Xamarin.Auth;

namespace Ins.Core.ViewModels
{
    public class LoginPageViewModel: BaseMvxViewModel
    {
        private readonly IUIService _uiService;
        private readonly IUserService _userService;
        private readonly IDataBaseService<User> _dataBaseService;

        private User _user;
        public User User
        {
            get => _user;
            set
            {
                if (SetProperty(ref _user, value))
                    RaisePropertyChanged(() => _user);
            }
        }

        public ICommand OnLogIn { get; private set; }
        public ICommand OnSignUp { get; private set; }
        public ICommand OnLogInViaFacebook { get; private set; }
        
        public LoginPageViewModel(IUserService userService, IDataBaseService<User> dataBaseService, IUIService uiService)
        {
            _uiService = uiService;
            _userService = userService;
            _dataBaseService = dataBaseService;

            _user = _userService.GetCurrentUser();
           _dataBaseService.CreateDataBase();

            OnLogIn = new MvxCommand(LogInClicked);
            OnSignUp = new MvxCommand(SignUpClicked);
            OnLogInViaFacebook = new MvxCommand(LogInViaFacebookClicked);
        }

        void SignUpClicked()
        {
            _userService.Reset();
            ShowViewModel<RegistrationPageViewModel>();
        }

        void LogInClicked()
        {           
            if ( _userService.IsCorrect(User) && _dataBaseService.InDataBase(User.Email) ){
                ShowViewModel<TabPageViewModel>();
            }
            else{
                Error = "Error, please check the entered information!";
            }
        }

        async Task SendRequest(Account account)
        {
            var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me?fields=name,email,picture"), null, account);
            var response = await request.GetResponseAsync();
            var text = response.GetResponseText();

            User user = JsonConvert.DeserializeObject<User>(response.GetResponseText());
            _userService.SetUser(user);
            ShowViewModel<TabPageViewModel>();
        }

        void LogInViaFacebookClicked()
        {
            if (User.IsRegistered){ 
                var accounts = AccountStore.Create().FindAccountsForService("Facebook").ToList();
                Account account = accounts.First();
                SendRequest(account).Wait();
            }
            else{
                var auth = new OAuth2Authenticator(
                    scope: "", 
                    clientId: ConstantHelper.userId, 
                    redirectUrl: ConstantHelper.redirectUrl,
                    authorizeUrl: ConstantHelper.authorizeUrl);

                auth.Completed += Auth_Completed;
                var ui = _uiService.GetUI(auth);

                _uiService.ShowUI(ui);
            }

        }

        private async void Auth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            _uiService.DismissUI();

            if (e.IsAuthenticated){
                AccountStore.Create().Save(e.Account, "Facebook");
                await SendRequest(e.Account);
            }
            else
            {
                // TO DO
            }
        }
    }
}