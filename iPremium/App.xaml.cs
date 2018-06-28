using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using iPremium.Views;
using iPremium.Services;
using iPremium.Enums;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace iPremium
{
    public partial class App : Application
    {
        private static NavigationService _navigationService;
        public static NavigationService NavigationService
        {
            get
            {
                return _navigationService ?? (_navigationService = new NavigationService());
            }
        }

        public App()
        {
            InitializeComponent();

            NavigationService.Configure(AppPages.LoginPage, typeof(LoginPage));
            NavigationService.Configure(AppPages.AboutPage, typeof(AboutPage));
            NavigationService.Configure(AppPages.AppointmentDetailPage, typeof(AppointmentDetailPage));
            NavigationService.Configure(AppPages.FeedDetailPage, typeof(FeedDetailPage));
            NavigationService.Configure(AppPages.FeedsPage, typeof(FeedsPage));
            NavigationService.Configure(AppPages.MainTabbedPage, typeof(MainTabbedPage));
            NavigationService.Configure(AppPages.RegisterPage, typeof(RegisterPage));
            NavigationService.Configure(AppPages.SchedulePage, typeof(SchedulePage));
            NavigationService.Configure(AppPages.UserInfoPage, typeof(UserInfoPage));

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
