using System;
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

        private bool _isShowingAddNewPopUp;
        public bool IsShowingAddNewPopUp
        {
            get { return _isShowingAddNewPopUp; }
            set{
                SetProperty(ref _isShowingAddNewPopUp, value);
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

        #region Commands
        public ICommand AddNewCommand { get; }
        #endregion

        #region Constructor
        public SchedulePageViewModel()
        {
            AddNewCommand = new Command(AddNewSchedule);
            InitData(null);
            MessagingCenter.Subscribe<FeedDetailPageViewModel,Feed>(this, "InitData", (sender,obj) => InitData(obj));
        }

        #endregion

        #region Methods
        void InitData(Feed item)
        {
            ListSchedules = new ObservableCollection<Schedule>() { new Schedule{ Name="Assistência Técnica",Time = DateTime.Now.ToString(),Status="Confirmado", Code="970 834 847"},
                new Schedule{ Name="Vendas",Time = DateTime.Now.ToString(),Status="Confirmado", Code="970 834 847"},
                new Schedule{ Name="Assistência Técnica",Time = DateTime.Now.ToString(),Status="Pendente", Code="970 834 847"},
                new Schedule{ Name="Assistência Técnica",Time = DateTime.Now.ToString(),Status="Confirmado", Code="970 834 847"}};   
        }
        private void AddNewSchedule()
        {
            
        }
        #endregion
    }
}
