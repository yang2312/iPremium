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
        #region Commands
        public ICommand RegisterCommand { get; }
        public ICommand LoginCommand { get; }
        #endregion

        #region Constructor
        public LoginPageViewModel()
        {
            RegisterCommand = new Command(NavigateToRegisterPage);

            LoginCommand = new Command(Login);
        }

        #endregion

        #region Methods

        private void Login()
        {
            var page = new NavigationPage(new MainTabbedPage());
            App.Current.MainPage = new MainTabbedPage();
        }

        private void NavigateToRegisterPage()
        {
            App.Current.MainPage = new RegisterPage();
        }
        #endregion
    }
}
