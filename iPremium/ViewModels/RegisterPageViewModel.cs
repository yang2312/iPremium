using iPremium.Services;
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
        #region Properties
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
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
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                SetProperty(ref _email, value);
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                SetProperty(ref _phone, value);
            }
        }
        #endregion

        #region Commands
        public ICommand BackCommand { get; }
        public ICommand RegisterCommand { get; }
        #endregion

        #region Constructor
        public RegisterPageViewModel()
        {
            BackCommand = new Command(NavigateBackToLoginPage);

            RegisterCommand = new Command(Register);
        }

        #endregion

        #region Methods
        private void NavigateBackToLoginPage(object obj)
        {
            App.Current.MainPage = new LoginPage();
        }
        private async void Register(){
            var result = await ApiService.Instance.HandleMemberRegistration(Name, Password, Email, Phone);

            if(result != null){
                await App.Current.MainPage.DisplayAlert("Notar", "Registro bem sucedido.", "OK");
                App.Current.MainPage = new MainTabbedPage();
            }
        }
        #endregion
    }
}
