using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iPremium.Views
{
    public partial class SchedulePage : ContentPage
    {
        public SchedulePage()
        {
            InitializeComponent();
        }

        private void CustomListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }
    }
}
