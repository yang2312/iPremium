using System;
namespace iPremium.Services
{
    public class ValidateService
    {
        private static ValidateService _instance;
        public static ValidateService Instance{
            get { return _instance ?? (_instance = new ValidateService()); }
        }

        public bool ValidatePassword(string password){
            return (!string.IsNullOrEmpty(password)) && (password.Length > 8);
        }
        public bool ValidateUserName(string userName,string email){
            return !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(email) && userName.Equals(email);
        }
    }
}
