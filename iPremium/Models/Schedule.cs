using System;
namespace iPremium.Models
{
    public class Schedule: ObservableObject
    {
        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
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

        private DateTime _start;
        public DateTime Start
        {
            get { return _start; }
            set
            {
                _start = value;
                OnPropertyChanged(nameof(Start));
            }
        }
        private DateTime _end;
        public DateTime End
        {
            get { return _end; }
            set
            {
                _end = value;
                OnPropertyChanged(nameof(End));
            }
        }
        private bool _editable;
        public bool Editable
        {
            get { return _editable; }
            set
            {
                _editable = value;
                OnPropertyChanged(nameof(Editable));
            }
        }
        private string _customer;
        public string Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }
        private string _color;
        public string Color
        {
            get { return _color; }
            set
            {
                _color = value;
                OnPropertyChanged(nameof(Color));
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
        private string _assignedName;
        public string AssignedName
        {
            get { return _assignedName; }
            set
            {
                _assignedName = value;
                OnPropertyChanged(nameof(AssignedName));
            }
        }
        private int _assignedTo;
        public int AssignedTo
        {
            get { return _assignedTo; }
            set
            {
                _assignedTo = value;
                OnPropertyChanged(nameof(AssignedTo));
            }
        }
    }
}
