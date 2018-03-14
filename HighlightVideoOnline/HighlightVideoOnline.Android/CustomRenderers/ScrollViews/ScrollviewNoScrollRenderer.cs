using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using HighlightVideoOnline.CustomRender;
using HighlightVideoOnline.Droid.CustomRenderers.ScrollViews;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ScrollviewNoScrollCustom), typeof(ScrollviewNoScrollRenderer))]
namespace HighlightVideoOnline.Droid.CustomRenderers.ScrollViews
{
    public class ScrollviewNoScrollRenderer : ScrollViewRenderer
    {
        public ScrollviewNoScrollRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            if (e.OldElement != null)
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;

            e.NewElement.PropertyChanged += OnElementPropertyChanged;



        }

        protected void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //if (this.Element != null && ChildCount > 0)
            //{
            //    GetChildAt(0).HorizontalScrollBarEnabled = false;
            //    GetChildAt(0).VerticalScrollBarEnabled = false;
            //}
            this.HorizontalScrollBarEnabled = false;
            this.VerticalScrollBarEnabled = false;
        }
    }
}