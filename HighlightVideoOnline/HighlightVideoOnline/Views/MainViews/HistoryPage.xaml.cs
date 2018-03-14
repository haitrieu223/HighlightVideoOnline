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
    public partial class HistoryPage : ContentView
    {
        public HistoryPage()
        {
            InitializeComponent();
            var historyViewModel = new HistoryViewModel();
            Task.Factory.StartNew(() =>
            {
                historyViewModel.SetDataDefault();
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.BindingContext = historyViewModel;
                });
            });
        }
        
    }
}