using System;
using System.Windows.Input;
using iPremium.Models;
using iPremium.Services;
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
        private bool _isShowingCancelingPopUp;
        public bool IsShowingCancelingPopUp{
            get { return _isShowingCancelingPopUp; }
            set
            {
                SetProperty(ref _isShowingCancelingPopUp, value);
            }
        }
        #endregion

        #region Command
        public ICommand ShowCancelPopupCommand { get; }
        public ICommand CloseCancelPopupCommand { get; }
        public ICommand GoBackCommand { get; }
        public ICommand CancelBookingCommand { get; }
        #endregion

        #region Constructor
        public AppointmentDetailPageViewModel()
        {
            MessagingCenter.Subscribe<SchedulePageViewModel, Schedule>(this, "ViewScheduleDetail", (sender,obj) => 
                {
                    ScheduleItem = obj;
                    IsShowingScheduleDetail = true;
                });
            GoBackCommand = new Command(() => IsShowingScheduleDetail = false);

            ShowCancelPopupCommand = new Command(() =>
            {
                IsShowingCancelingPopUp = true;
            });
            CloseCancelPopupCommand = new Command(() =>
            {
                IsShowingCancelingPopUp = false;
            });
            CancelBookingCommand = new Command(async () => {
                var result = await ApiService.Instance.CancelBooking(ScheduleItem);

                await App.Current.MainPage.DisplayAlert("Notar", result ? "Compromisso cancelado com sucesso" : "Cancelamento de nomeação sem sucesso", "OK");

                if(result)
                {
                    IsShowingCancelingPopUp = false;
                    IsShowingScheduleDetail = false;
                    MessagingCenter.Send(this, "RemoveItemSuccessfully");
                }
            });
        }
        #endregion  
    }
}
