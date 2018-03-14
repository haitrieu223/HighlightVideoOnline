using Android.Widget;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Android.Views;


namespace HighlightVideoOnline.CustomRender
{
    public class NativeLabel : StackLayout
    {
        public NativeAndroidLabel NativeAndroidLabel;
        public NativeIosLabel NativeIosLabel;
        public NativeLabel()
        {
            var textView = new TextView(Android.App.Application.Context);
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    NativeAndroidLabel = new NativeAndroidLabel();
                    break;
                case Device.iOS:
                    NativeIosLabel = new NativeIosLabel();
                    break;
            }
        }
    }
}
