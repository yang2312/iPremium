using System;
using System.Collections.Generic;
using System.Text;

namespace iPremium.Models
{
    public class Feed: ObservableObject
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
        private string _subTitle;
        public string SubTitle
        {
            get { return _subTitle; }
            set
            {
                _subTitle = value;
                OnPropertyChanged(nameof(SubTitle));
            }
        }
        private string _image;
        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        private string _desciption;
        public string Desciption
        {
            get { return _desciption; }
            set
            {
                _desciption = value;
                OnPropertyChanged(nameof(Desciption));
            }
        }
    }
}
