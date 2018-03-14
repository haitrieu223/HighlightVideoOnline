using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HighlightVideoOnline.CustomRender;
using HighlightVideoOnline.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ImageTintColor), typeof(ImageTintColorRenderer))]
namespace HighlightVideoOnline.Droid.CustomRenderers
{
    public class ImageTintColorRenderer : ImageRenderer 
    {
        public ImageTintColorRenderer(Context context): base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            SetTint();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ImageTintColor.TintColorProperty.PropertyName)
                SetTint();
        }

        void SetTint()
        {
            if (Control == null || Element == null)
                return;

            if (((ImageTintColor)Element).TintColor.Equals(Xamarin.Forms.Color.Transparent))
            {
                //Turn off tinting

                if (Control.ColorFilter != null)
                    Control.ClearColorFilter();

                return;
            }
            //Apply tint color
            var colorFilter = new PorterDuffColorFilter(((ImageTintColor)Element).TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
            Control.SetColorFilter(colorFilter);
        }
    }
}