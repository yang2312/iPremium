using System;
using System.Collections.Generic;
using System.Text;

namespace iPremium.Models
{
    public class NewBookingModel: ObservableObject
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
        public DateTime Start { get; set; }
        private int _status;
        public int Status
        {
            get { return 1; }
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
            get { return App.UserInfo != null ? App.UserInfo.Phone : _phone; }
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
            get { return App.UserInfo != null ? App.UserInfo.Username : _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public static explicit operator NewBookingModel(CreateBookingModel createBookingModel)
        {
            return new NewBookingModel
            {
                Title = createBookingModel.Title,
                AllDay = createBookingModel.AllDay,
                Start = createBookingModel.Start,
                //Status = createBookingModel.Status,
                Customer = createBookingModel.Customer,
                Phone = createBookingModel.Phone,
                AsssignedTo = createBookingModel.AsssignedTo,
                Email = createBookingModel.Email
            };
        }
    }
}
