using HighlightVideoOnline.Commons;
using HighlightVideoOnline.CustomRender.Pages;
using HighlightVideoOnline.Models.Objects;
using HighlightVideoOnline.Views.MainViews;
using HighlightVideoOnline.Views.Videos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HighlightVideoOnline.ViewModels.MainViewModels
{
    public class MainPageViewModel : BaseViewModel
    {

        private View _MainContentView = new HomePage();
        public View MainContentView
        {
            get { return _MainContentView; }
            set
            {
                _MainContentView = value;
                OnPropertyChanged(nameof(MainContentView));
            }
        }

        public ICommand ScrollViewChanged
        {
            get
            {
                return new Command((obj) =>
                {
                    try
                    {
                        if (obj != null)
                        {
                            var scrollPosition = obj as Tuple<double, double>;
                            MessagingCenter.Send(this, Commons.ConstMessage.MESSAGE_SCROLLED_EVENT, new Tuple<double, double>(scrollPosition.Item1, scrollPosition.Item2));
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                });
            }
        }
        public override Task OnAppearing(Page page)
        {
            MessagingCenter.Subscribe<CustomRender.ListViewShowAll, Tuple<VideoInfoFormatter, TransitionType>>(this, AppSettings.TransitionMessage, (sender, e) =>
            {
                var transitionType = (TransitionType)e.Item2;
                // Kiểm tra đang sử dụng có phải là trang cha TransitionNavigationPage
                var transitionNavigationPage = page.Parent as TransitionNavigationPage;

                if (transitionNavigationPage != null)
                {
                    transitionNavigationPage.TransitionType = transitionType;
                    App.Current.MainPage.Navigation.PushAsync(new VideoPage());
                }
            });
            return base.OnAppearing(page);
        }

        public override Task OnDisappearing(Page page)
        {
            MessagingCenter.Unsubscribe<CustomRender.ListViewShowAll, Tuple<VideoInfoFormatter, TransitionType>>(this, AppSettings.TransitionMessage);
            return base.OnDisappearing(page);
        }

        public MainPageViewModel()
        {
            MessagingCenter.Subscribe<BottomTabViewModel, View>(this, ConstMessage.SET_MAIN_VIEW, (sender, e) =>
            {
                Task.Factory.StartNew(() =>
                {
                    MainContentView = null;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        MainContentView = e;
                        MainContentView.TranslateTo(0, MainContentView.TranslationY, 500, Easing.CubicOut);
                    });
                });
            });
        }
    }
}
