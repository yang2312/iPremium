using iPremium.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace iPremium.ViewModels
{
    public class FeedsPageViewModel: BaseViewModel
    {
        #region Properties
        private ObservableCollection<Feed> _listFeeds;
        public ObservableCollection<Feed> ListFeeds
        {
            get
            {
                return _listFeeds == null ? _listFeeds = new ObservableCollection<Feed>() : _listFeeds;
            }
            set
            {
                SetProperty(ref _listFeeds, value);
            }
        }

        private Feed _selectedFeedItem;
        public Feed SelectedFeedItem
        {
            get
            {
                return _selectedFeedItem;
            }
            set
            {
                SetProperty(ref _selectedFeedItem, value);
            }
        }
        #endregion

        #region Constructor
        public FeedsPageViewModel()
        {
            ListFeeds = new ObservableCollection<Feed>() { new Feed { Title = "ONE 2 ONE", SubTitle = "ASSISTÊNCIA NA SUA EMPRESA", Image = "one2one.png", Desciption = "SDAR DGFDG RDG DSFSDRF WSRF DSCVXC" },
                                                            new Feed { Title = "PRODUTOS APPLE", SubTitle = "SINTA-SE EM CASE", Image = "mac.png", Desciption = "SD FG FG WFDSFFSDF FGB DBDFGD" },
                                                            new Feed { Title = "APRENDE APPLÊS", SubTitle = "TAS TFE VDSD BD", Image = "screen_learn.png", Desciption = "SVGSFVSVGD EW FGDFVVBGBFE DSF VCXVSF WEFDF VCX VXCV SG GHBGHNRYGERTFR FDG DF G"} };
        }
        #endregion

        #region Commands
        #endregion

        #region Methods
        #endregion
    }
}
