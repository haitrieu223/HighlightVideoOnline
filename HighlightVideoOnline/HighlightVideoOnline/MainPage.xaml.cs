using HighlightVideoOnline.Commons;
using HighlightVideoOnline.CustomRender;
using HighlightVideoOnline.CustomRender.Pages;
using HighlightVideoOnline.Models.Objects;
using HighlightVideoOnline.Models.Objects.Infos;
using HighlightVideoOnline.ViewModels.MainViewModels;
using HighlightVideoOnline.Views;
using HighlightVideoOnline.Views.Videos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HighlightVideoOnline
{
    public partial class MainPage : BaseView<MainPageViewModel>
    {
        public MainPage()
        {
            InitializeComponent();
            //var mainPageViewModel = new MainPageViewModel();
            //Task.Factory.StartNew(() =>
            //{
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        this.BindingContext = mainPageViewModel;
            //    });
            //}); 
        }

        //public void Scroll_Scrolled(object sender, ScrolledEventArgs e)
        //{
        //    try
        //    {
        //        MessagingCenter.Send(this, Commons.ConstMessage.MESSAGE_SCROLLED_EVENT, new Tuple<double,double>(e.ScrollX,e.ScrollY));
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }
        //}
    }
}
