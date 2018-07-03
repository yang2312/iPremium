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
            
            Control.AttributedPlaceholder = new Foundation.NSAttributedString(Control.Placeholder, new UIStringAttributes { ForegroundColor = Control.TextColor, Font=UIFont.FromName("Avenir Next",10)});
            Control.Layer.BorderColor = Control.TextColor.CGColor;
            Control.Layer.BorderWidth = 1;
            Control.Layer.CornerRadius = 10;
        }
    }
}
