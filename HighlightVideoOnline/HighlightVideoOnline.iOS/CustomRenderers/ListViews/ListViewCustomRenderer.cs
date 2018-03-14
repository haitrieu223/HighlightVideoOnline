using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using HighlightVideoOnline.CustomRender;
using Xamarin.Forms;
using HighlightVideoOnline.iOS.CustomRenderers.ListViews;

[assembly: ExportRenderer(typeof(ListViewCustom), typeof(ListViewCustomRenderer))]
namespace HighlightVideoOnline.iOS.CustomRenderers.ListViews
{
    public class ListViewCustomRenderer : ListViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                var listViewCustom = Element as ListViewCustom;
                var listView = this.Control as UITableView;
                if (e.NewElement != null)
                {
                    if (listViewCustom.IsVisibleScroll)
                    {
                        listView.ShowsVerticalScrollIndicator = true;
                    }else
                    {
                        listView.ShowsVerticalScrollIndicator = false;
                    }
                    if (listViewCustom.IsScrollAll)
                    {
                        listView.ScrollsToTop = true;
                    }
                }
            }
        }
    }
}
