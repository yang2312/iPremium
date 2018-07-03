using System;
using System.Collections.Generic;
using System.Text;

namespace iPremium.Models
{
    public class CreateBookingModel:ObservableObject
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        private bool _allDay;
        public bool AllDay
        {
            get { return _allDay; }
            set
            {
                _allDay = value;
                OnPropertyChanged(nameof(AllDay));
            }
        }
        public DateTime Start
        {
            get { return DateStart + TimeStart; }
        }
        private int _status;
        public int Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        private string _customer;
        public string Customer
        {
            get { return App.UserInfo != null ? App.UserInfo.Username : _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        private int _asssignedTo;
        public int AsssignedTo
        {
            get { return _asssignedTo; }
            set
            {
                _asssignedTo = value;
                OnPropertyChanged(nameof(AsssignedTo));
            }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        private DateTime _dateStart = DateTime.Now;
        public DateTime DateStart
        {
            get { return _dateStart; }
            set
            {
                _dateStart = value;
                OnPropertyChanged(nameof(DateStart));
            }
        }
        private TimeSpan _timeStart = DateTime.Now.TimeOfDay.Add(TimeSpan.FromHours(1));
        public TimeSpan TimeStart
        {
            get { return _timeStart; }
            set
            {
                _timeStart = value;
                OnPropertyChanged(nameof(TimeStart));
            }
        }
    }
}
