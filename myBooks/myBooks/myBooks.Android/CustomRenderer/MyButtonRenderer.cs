using System.ComponentModel;
using Android.Content;
using myBooks.CustomRenderer;
using myBooks.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MyButton), typeof(MyButtonRenderer))]
namespace myBooks.Droid.CustomRenderer
{
    public class MyButtonRenderer : ButtonRenderer
    {
        public MyButtonRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            TabMenuOff(Control);
            //Buttons Sign In/Up Pages

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

        private void TabMenuOn(Android.Widget.Button Control)
        {
            Control.SetWidth(346);
            Control.SetAllCaps(false);
            Control.PaintFlags |= Android.Graphics.PaintFlags.UnderlineText;

        }

        private void TabMenuOff(Android.Widget.Button Control)
        {
            Control.SetWidth(346);
            Control.SetAllCaps(false);
        }
    }
}