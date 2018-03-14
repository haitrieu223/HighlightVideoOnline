using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HighlightVideoOnline.CustomRender
{
    public class StackValue : StackLayout
    {
        public static readonly BindableProperty ValueProperty = BindableProperty.Create("Value", typeof(object), typeof(StackValue), null);
        public object Value
        {
            get { return GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
            }
        }
        public StackValue()
        {

        }
    }
}
