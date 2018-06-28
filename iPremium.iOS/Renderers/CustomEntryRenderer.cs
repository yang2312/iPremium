using System;
using iPremium.Controls;
using iPremium.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace iPremium.iOS.Renderers
{
    public class CustomEntryRenderer: EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control.TextAlignment = UITextAlignment.Center;
            Control.Layer.BorderColor = UIColor.White.CGColor;
            Control.Layer.BorderWidth = 1;
            Control.Layer.CornerRadius = 5;
        }
    }
}
