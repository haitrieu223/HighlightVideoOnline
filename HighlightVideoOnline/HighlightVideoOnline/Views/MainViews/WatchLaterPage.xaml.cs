using HighlightVideoOnline.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HighlightVideoOnline.Views.MainViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WatchLaterPage : ContentView
    {
		public WatchLaterPage ()
		{
			InitializeComponent ();
            var watchLaterViewModel = new WatchLaterViewModel();
            Task.Factory.StartNew(() =>
            {
                watchLaterViewModel.SetDataDefault();
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.BindingContext = watchLaterViewModel;
                });
            });
        }
	}
}