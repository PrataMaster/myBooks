using System.ComponentModel;
using Android.Content;
using myBooks.CustomRenderer;
using myBooks.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyLabel), typeof(MyLabelRenderer))]
namespace myBooks.Droid.CustomRenderer
{
    public class MyLabelRenderer : LabelRenderer
    {
        public MyLabelRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            Control.PaintFlags |= Android.Graphics.PaintFlags.UnderlineText;
            Control.SetBackgroundColor(Android.Graphics.Color.Maroon);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

    }
}