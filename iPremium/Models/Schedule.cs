using System;
namespace iPremium.Models
{
    public class Schedule: ObservableObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set{
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _time;
        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
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
        private string _code;
        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                OnPropertyChanged(nameof(Code));
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
    }
}
