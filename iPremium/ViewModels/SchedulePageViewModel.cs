using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using iPremium.Models;
using iPremium.Services;
using iPremium.Views;
using Xamarin.Forms;

namespace iPremium.ViewModels
{
    public class SchedulePageViewModel: BaseViewModel
    {
        #region Properties
        private ObservableCollection<Schedule> _listSchedules;
        public ObservableCollection<Schedule> ListSchedules
        {
            get
            {
                return _listSchedules == null ? _listSchedules = new ObservableCollection<Schedule>() : _listSchedules;
            }
            set
            {
                SetProperty(ref _listSchedules, value);
            }
        }

        private Schedule _selectedSchedule;
        public Schedule SelectedSchedule
        {
            get
            {
                return _selectedSchedule;
            }
            set
            {
                SetProperty(ref _selectedSchedule, value);
                if (_selectedSchedule != null)
                {
                    MessagingCenter.Send(this, "ViewScheduleDetail", _selectedSchedule);
                }
            }
        }

        private CreateBookingModel _newBookingItem;
        public CreateBookingModel NewBookingItem
        {
            get { return _newBookingItem; }
            set{
                SetProperty(ref _newBookingItem, value);
            }
        }

        private bool _isShowingAddNewPopUp;
        public bool IsShowingAddNewPopUp
        {
            get { return _isShowingAddNewPopUp; }
            set{
                SetProperty(ref _isShowingAddNewPopUp, value);
            }
        }

        #endregion

        #region Commands
        public ICommand AddNewCommand { get; }
        public ICommand ShowAddNewPopupCommand { get; }
        public ICommand DisposeAddNewPopupCommand { get; }
        #endregion

        #region Constructor
        public SchedulePageViewModel()
        {
            AddNewCommand = new Command(AddNewSchedule);
            ShowAddNewPopupCommand = new Command(() => IsShowingAddNewPopUp = true);
            DisposeAddNewPopupCommand = new Command(() => IsShowingAddNewPopUp = false);

            InitData();
            MessagingCenter.Subscribe<FeedDetailPageViewModel>(this, "InitData", (sender) => InitData());

            MessagingCenter.Subscribe<AppointmentDetailPageViewModel>(this, "RemoveItemSuccessfully", (sender) =>
            {
                IsShowingAddNewPopUp = false;
                InitData();
            });
        }

        #endregion

        #region Methods
        async void InitData()
        {
            if(App.UserInfo != null)
            {
                var list = await ApiService.Instance.GetBookingsForCustomer(App.UserInfo.Username);
                if (list != null)
                    ListSchedules = new ObservableCollection<Schedule>(list);
            }
        }
        private async void AddNewSchedule()
        {
            if(App.UserInfo == null){
                App.Current.MainPage = new LoginPage();
            }
            var result = await ApiService.Instance.SaveBooking(NewBookingItem);

            await App.Current.MainPage.DisplayAlert("Notar", result ? "Faça o calendário bem sucedido" : "Confirmar um compromisso", "OK");

            IsShowingAddNewPopUp = false;

        }
        #endregion
    }
}
