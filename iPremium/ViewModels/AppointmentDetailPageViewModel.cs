using System;
using System.Windows.Input;
using iPremium.Models;
using Xamarin.Forms;

namespace iPremium.ViewModels
{
    public class AppointmentDetailPageViewModel : BaseViewModel
    {
        #region Properties
        private Schedule _scheduleItem;
        public Schedule ScheduleItem
        {
            get
            {
                return _scheduleItem;
            }
            set
            {
                SetProperty(ref _scheduleItem, value);
            }
        }
        private bool _isShowingScheduleDetail;
        public bool IsShowingScheduleDetail
        {
            get { return _isShowingScheduleDetail; }
            set
            {
                SetProperty(ref _isShowingScheduleDetail, value);
            }
        }
        #endregion

        #region Command
        public ICommand ShowCancelPopupCommand { get; }
        #endregion

        #region Constructor
        public AppointmentDetailPageViewModel()
        {
            MessagingCenter.Subscribe<SchedulePageViewModel, Schedule>(this, "ViewScheduleDetail", (sender,obj) => 
                {
                    ScheduleItem = obj;
                    IsShowingScheduleDetail = true;
                });

        }
        #endregion  
    }
}
