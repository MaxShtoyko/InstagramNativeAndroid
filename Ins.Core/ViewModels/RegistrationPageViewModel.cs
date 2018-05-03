using Ins.Core.Interfaces;
using Ins.Core.Models;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace Ins.Core.ViewModels
{
    public class RegistrationPageViewModel:BaseMvxViewModel
    {
        private readonly IUserService _userService;
        private readonly IErrorService _errorService;
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

        public ICommand OnSignUp { get; private set; }
        
        public RegistrationPageViewModel(IUserService userService, IDataBaseService<User> dataBaseService, IErrorService errorService)
        {
            _userService = userService;
            _dataBaseService = dataBaseService;
            _errorService = errorService;

            _user = _userService.GetCurrentUser();

            OnSignUp = new MvxCommand(SignUpClicked);
        }

        void SignUpClicked()
        {
            if ( _userService.IsCorrect(_user) )
            {
                if(!_dataBaseService.InDataBase(User.Email)){
                    _dataBaseService.InsertIntoTable(User);
                    ShowViewModel<LoginPageViewModel>();
                }
                else{
                    _errorService.ShowError("Error, this email is already in use!");
                }
            }
            else{
                _errorService.ShowError("Error, please check the entered information!");
            }
        }
    }
}