﻿using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using iPremium.Models;
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

            InitData(null);
            MessagingCenter.Subscribe<FeedDetailPageViewModel,Feed>(this, "InitData", (sender,obj) => InitData(obj));
        }

        #endregion

        #region Methods
        void InitData(Feed item)
        {
            
        }
        private void AddNewSchedule()
        {
             
        }
        #endregion
    }
}
