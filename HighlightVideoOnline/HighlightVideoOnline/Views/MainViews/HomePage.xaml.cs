using HighlightVideoOnline.CustomRender;
using HighlightVideoOnline.ViewModels;
using HighlightVideoOnline.ViewModels.MainViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HighlightVideoOnline.Views.MainViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentView
    {
        public HomePage()
        {
            InitializeComponent();
            var model = new HomeViewModel();
            Task.Factory.StartNew(() =>
            {
                model.SetDataDefault();
                Device.BeginInvokeOnMainThread(() =>
                {
                    this.BindingContext = model;
                });
            });
            MessagingCenter.Subscribe<MainPageViewModel, Tuple<double, double>>(this, Commons.ConstMessage.MESSAGE_SCROLLED_EVENT, (sender, e) =>
             {
                 frameCategory.TranslateTo(frameCategory.TranslationX, e.Item2, 500, easing: Easing.BounceOut);
             });
        }

        public void frameCategoryTap_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushModalAsync(new CommonView.MenuCategoryView());

        }
    }
}