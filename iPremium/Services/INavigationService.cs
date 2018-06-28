using System;
using iPremium.Enums;
using Xamarin.Forms;

namespace iPremium.Services
{
    public interface INavigationService
    {
        void GoBack();
        void NavigateTo(AppPages pageKey);
        void NavigateTo(AppPages pageKey, object parameter);
        void Configure(AppPages pageKey, Type pageType);
        void Initialize(NavigationPage navigation);
    }
}
