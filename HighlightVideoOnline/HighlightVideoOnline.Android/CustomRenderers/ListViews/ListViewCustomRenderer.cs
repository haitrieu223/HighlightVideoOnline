using Android.Content;
using HighlightVideoOnline.CustomRender;
using HighlightVideoOnline.Droid.CustomRenderers.ListViews;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ListViewCustom), typeof(ListViewCustomRenderer))]
namespace HighlightVideoOnline.Droid.CustomRenderers.ListViews
{
    public class ListViewCustomRenderer : ListViewRenderer
    {
        public ListViewCustomRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var listViewCustom = Element as ListViewCustom;
                var listView = this.Control as Android.Widget.ListView;
                if (e.NewElement != null)
                {
                    if (listViewCustom.IsVisibleScroll)
                    {
                        listView.VerticalScrollBarEnabled = true;
                    }else
                    {
                        listView.VerticalScrollBarEnabled = false;
                    }
                    if (listViewCustom.IsScrollAll)
                    {
                        listView.SmoothScrollToPositionFromTop(0, 0);
                    }
                }
            }
        }
    }
}