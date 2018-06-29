using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iPremium.Views
{
    public partial class FeedsPage : ContentPage
    {
        public FeedsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            FeedListView.SelectedItem = null;
        }
    }
}
