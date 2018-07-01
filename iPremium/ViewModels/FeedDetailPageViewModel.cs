using iPremium.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace iPremium.ViewModels
{
    public class FeedDetailPageViewModel: BaseViewModel
    {
        #region Properties
        private Feed _feedItem;
        public Feed FeedItem
        {
            get
            {
                return _feedItem;
            }
            set
            {
                SetProperty(ref _feedItem, value);
            }
        }
        private bool _iShowingFeedDetail = false;
        public bool IsShowingFeedDetail
        {
            get { return _iShowingFeedDetail; }
            set
            {
                SetProperty(ref _iShowingFeedDetail, value);
            }
        }
        #endregion

        #region Commands
        public ICommand GoBackCommand { get; }
        public ICommand NavigateToCalendarCommand { get; }
        #endregion

        #region Constructor
        public FeedDetailPageViewModel()
        {
            MessagingCenter.Subscribe<FeedsPageViewModel,Feed>(this, "UpdateItem", (sender,obj) =>
            {
                FeedItem = obj;
                IsShowingFeedDetail = true;
            });
            GoBackCommand = new Command(() => IsShowingFeedDetail = false);

            NavigateToCalendarCommand = new Command(NavigateToCalendar);
        }


        #endregion

        #region Methods
        private void NavigateToCalendar()
        {
            MessagingCenter.Send(this, "InitData",FeedItem);
            MessagingCenter.Send(this, "ChangeToCalendarTab");
        }
        #endregion
    }
}
