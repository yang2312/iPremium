using iPremium.Models;
using iPremium.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace iPremium.Views
{
    public partial class FeedDetailPage : Grid
    {
        #region Static Public Properties
        public static readonly BindableProperty FeedItemProperty = BindableProperty.Create("FeedItem",
           typeof(Feed), typeof(FeedDetailPage), default(Feed));
        public Feed FeedItem
        {
            get { return (Feed)GetValue(FeedItemProperty); }
            set { SetValue(FeedItemProperty, value); }
        }
        #endregion
        public FeedDetailPage()
        {
            InitializeComponent();
        }
    }
}
