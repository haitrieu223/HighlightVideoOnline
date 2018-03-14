using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HighlightVideoOnline.CustomRender
{
    public class ImageTintColor : Image
    {
        public static readonly BindableProperty TintColorProperty = BindableProperty.Create(nameof(TintColor), typeof(Color), typeof(ImageTintColor), Color.Black);
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(nameof(Value), typeof(object), typeof(ImageTintColor), null);

        public Color TintColor
        {
            get { return (Color)GetValue(TintColorProperty); }
            set { SetValue(TintColorProperty, value); }
        }

        public object Value
        {
            get { return (object)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    }
}
