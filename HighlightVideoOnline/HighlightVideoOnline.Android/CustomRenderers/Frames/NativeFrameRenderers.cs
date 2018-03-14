using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HighlightVideoOnline.CustomRender.Frames;
using HighlightVideoOnline.Droid.CustomRenderers.Frames;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(NativeFrame),typeof(NativeFrameRenderers))]
namespace HighlightVideoOnline.Droid.CustomRenderers.Frames
{
    public class NativeFrameRenderers : Xamarin.Forms.Platform.Android.FastRenderers.FrameRenderer
    {
        public NativeFrameRenderers(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
        }
    }
}