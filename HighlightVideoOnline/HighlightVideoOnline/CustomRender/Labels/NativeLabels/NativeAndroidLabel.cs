using Android.Widget;
using Xamarin.Android.Net;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;

namespace HighlightVideoOnline.CustomRender
{
    public class NativeAndroidLabel : TextView
    {
        public NativeAndroidLabel() : base(Android.App.Application.Context)
        {
        }
    }
}
