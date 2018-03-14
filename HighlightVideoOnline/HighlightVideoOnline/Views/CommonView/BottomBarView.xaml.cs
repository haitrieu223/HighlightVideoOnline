using HighlightVideoOnline.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HighlightVideoOnline.Views.CommonView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BottomBarView : ContentView
	{
		public BottomBarView ()
		{
			InitializeComponent ();
            //var model = new BottomTabViewModel();
            //Task.Factory.StartNew(() => {
            //    model.InitDataDefault();
            //    Device.BeginInvokeOnMainThread(() => {
            //        BindingContext = model;
            //    });
            //});
		}
	}
}