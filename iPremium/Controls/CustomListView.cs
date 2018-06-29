using System;
using Xamarin.Forms;

namespace iPremium.Controls
{
    public class CustomListView: ListView
    {
        protected override void SetupContent(Cell pContent, int pIndex)
        {
            base.SetupContent(pContent, pIndex);
            var currentViewCell = pContent as ViewCell;

            if (currentViewCell != null)
            {
                currentViewCell.View.BackgroundColor = pIndex % 2 == 0 ? Color.FromRgb(248, 248, 248) : Color.FromRgb(255, 255, 255);
            }
        }
        public CustomListView(ListViewCachingStrategy strategy) : base(strategy)
        {

        }
    }
}
