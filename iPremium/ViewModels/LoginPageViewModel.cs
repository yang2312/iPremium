using iPremium.Services;
using iPremium.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace iPremium.ViewModels
{
    public class LoginPageViewModel: BaseViewModel
    {
        #region Properties
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                SetProperty(ref _userName, value);
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                SetProperty(ref _password, value);
            }
        }
        #endregion

        #region Commands
        public ICommand RegisterCommand { get; }
        public ICommand LoginCommand { get; }
        public ICommand LoginAsGuestCommand { get; }
        #endregion

        #region Constructor
        public LoginPageViewModel()
        {
            RegisterCommand = new Command(NavigateToRegisterPage);

            LoginCommand = new Command(Login);

            LoginAsGuestCommand = new Command(LoginAsGuest);
        }

        #endregion

        #region Methods
        private void LoginAsGuest()
        {
            App.Current.MainPage = new MainTabbedPage();
        }

        private async void Login()
        {
            IsBusy = true;
            var result = await ApiService.Instance.HandleMemberLogin(UserName, Password);
            if (result)
            {
                var userInfo = await ApiService.Instance.GetMember(UserName);
                if(userInfo != null)
                {
                    App.UserInfo = new Models.Account { Name = userInfo.Name, Password = userInfo.Password, MemberType = userInfo.MemberType, Username = userInfo.Username,Message = userInfo.Message,Phone = userInfo.Phone };
                    App.Current.MainPage = new MainTabbedPage();
                    return;
                }
            }
            await App.Current.MainPage.DisplayAlert("Atenção","Nome de utilizador ou senha incorretos","Cancel");
            IsBusy = false;
        }

        private void NavigateToRegisterPage()
        {
            App.Current.MainPage = new RegisterPage();
        }
        #endregion
    }
}
