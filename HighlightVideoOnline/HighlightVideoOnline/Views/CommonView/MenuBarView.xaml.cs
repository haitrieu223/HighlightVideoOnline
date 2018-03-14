using HighlightVideoOnline.ViewModels.CommonViewModels;
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
    public partial class MenuBarView : ContentView
    {
        public MenuBarView()
        {
            InitializeComponent();
            var model = new MenuBarViewModels();
            Task.Factory.StartNew(() =>
            {
                model.SetTabInfoDefault();
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.BindingContext = model;
                });
            });
        }
    }
}