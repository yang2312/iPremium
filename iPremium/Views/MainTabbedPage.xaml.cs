using System;
using System.Collections.Generic;
using iPremium.ViewModels;
using Xamarin.Forms;

namespace iPremium.Views
{
    public partial class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
            InitializeComponent();

            Children.Add(new FeedsPage() { Icon = "home.png", Title = "Feed" });
            Children.Add(new SchedulePage() { Icon = "calendar.png", Title = "Marcação" });
            Children.Add(new UserInfoPage() { Icon = "gender.png", Title = "Perfil" });
            Children.Add(new AboutPage() { Icon = "double.png", Title = "Double" });

            MessagingCenter.Subscribe<FeedDetailPageViewModel>(this, "ChangeToCalendarTab", (sender) => CurrentPage = Children[1]);
        }

    }
}
