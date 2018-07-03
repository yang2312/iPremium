using iPremium.Models;
using iPremium.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace iPremium.ViewModels
{
    public class UserInfoPageViewModel: BaseViewModel
    {
        #region Properties
        private Account _userInfo;
        public Account UserInfo
        {
            get { return _userInfo; }
            set
            {
                SetProperty(ref _userInfo, value);
            }
        }
        private string _oldPassword;
        public string OldPassword
        {
            get { return _oldPassword; }
            set
            {
                SetProperty(ref _oldPassword, value);
            }
        }
        private string _newPassword;
        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                SetProperty(ref _newPassword, value);
            }
        }
        private bool _isShowingResetPassword;
        public bool IsShowingResetPassword
        {
            get { return _isShowingResetPassword; }
            set
            {
                SetProperty(ref _isShowingResetPassword, value);
            }
        }
        #endregion

        #region Command
        public ICommand ShowingResetPasswordCommand
        {
            get
            {
                return new Command(() => IsShowingResetPassword = !IsShowingResetPassword);
            }
        }
        public ICommand ResetPasswordCommand
        {
            get
            {
                return new Command(() => App.Current.MainPage.DisplayAlert("Notar", "Feature has not been implemented yet!", "OK"));
            }
        }
        public ICommand LogOutCommand
        {
            get
            {
                return new Command(() => 
                {
                    App.UserInfo = new Account();
                    App.Current.MainPage = new LoginPage();
                });
            }
        }
        #endregion

        #region Constructor
        public UserInfoPageViewModel()
        {
            UserInfo = App.UserInfo;
        }
        #endregion

    }
}
