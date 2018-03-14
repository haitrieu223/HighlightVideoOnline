using HighlightVideoOnline.CustomRender;
using HighlightVideoOnline.iOS.CustomRenderers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ImageTintColor), typeof(ImageTintColorRenderer))]
namespace HighlightVideoOnline.iOS.CustomRenderers
{
    public class ImageTintColorRenderer : ImageRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            SetTint();
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ImageTintColor.TintColorProperty.PropertyName)
                SetTint();
        }

        void SetTint()
        {
            if (Control?.Image == null || Element == null)
                return;

            if (((ImageTintColor)Element).TintColor == Color.Transparent)
            {
                //Turn off tinting
                Control.Image = Control.Image.ImageWithRenderingMode(UIKit.UIImageRenderingMode.Automatic);
                Control.TintColor = null;
            }
            else
            {
                //Apply tint color
                Control.Image = Control.Image.ImageWithRenderingMode(UIKit.UIImageRenderingMode.AlwaysTemplate);
                Control.TintColor = ((ImageTintColor)Element).TintColor.ToUIColor();
            }
        }
    }
}
