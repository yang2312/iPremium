using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iPremium.Views
{
    public partial class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
            InitializeComponent();
            var home = new FeedsPage() { Icon = "home.png", Title = "Feed" };
            App.NavigationService.Initialize(new NavigationPage(home));

            Children.Add(home);
            Children.Add(new SchedulePage() { Icon = "calendar.png", Title = "Marcação" });
            Children.Add(new UserInfoPage() { Icon = "gender.png", Title = "Perfil" });
            Children.Add(new AboutPage() { Icon = "double.png", Title = "Double" });

        }
    }
}
