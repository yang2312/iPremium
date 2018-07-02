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
        private string _image;
        public string Image
        {
            get { return _image; }
            set
            {
                if(!string.IsNullOrEmpty(value)){
                    _image = value.Replace("http://ipremium.double.pt", "http://ipremium.pt");
                }
                OnPropertyChanged(nameof(Image));
            }
        }
        private string _smallDescription;
        public string SmallDescription
        {
            get { return _smallDescription; }
            set
            {
                _smallDescription = value;
                OnPropertyChanged(nameof(SmallDescription));
            }
        }
        private int _leadOwner;
        public int LeadOwner
        {
            get { return _leadOwner; }
            set
            {
                _leadOwner = value;
                OnPropertyChanged(nameof(LeadOwner));
            }
        }
        private string _feedDetail;
        public string FeedDetail
        {
            get { return _feedDetail; }
            set
            {
                _feedDetail = value;
                OnPropertyChanged(nameof(FeedDetail));
            }
        }
    }
}
