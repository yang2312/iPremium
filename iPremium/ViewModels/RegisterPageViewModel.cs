using iPremium.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace iPremium.ViewModels
{
    public class RegisterPageViewModel: BaseViewModel
    {
        #region Commands
        public ICommand BackCommand { get; }
        #endregion

        #region Constructor
        public RegisterPageViewModel()
        {
            BackCommand = new Command(NavigateBackToLoginPage);
        }

        #endregion

        #region Methods
        private void NavigateBackToLoginPage(object obj)
        {
            App.Current.MainPage = new LoginPage();
        }
        #endregion
    }
}
