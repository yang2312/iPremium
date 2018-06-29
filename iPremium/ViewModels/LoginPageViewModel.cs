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
        #endregion

        #region Constructor
        public LoginPageViewModel()
        {
            RegisterCommand = new Command(NavigateToRegisterPage);
        }

        #endregion

        #region Methods

        private void NavigateToRegisterPage(object obj)
        {
            App.Current.MainPage = new RegisterPage();
        }
        #endregion
    }
}
