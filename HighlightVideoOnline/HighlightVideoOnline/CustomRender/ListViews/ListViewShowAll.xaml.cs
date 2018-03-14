using HighlightVideoOnline.Commons;
using HighlightVideoOnline.CustomRender.Pages;
using HighlightVideoOnline.Models.Objects;
using HighlightVideoOnline.Models.Objects.Infos;
using HighlightVideoOnline.ViewModels.MainViewModels;
using HighlightVideoOnline.Views.CommonView;
using HighlightVideoOnline.Views.Videos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HighlightVideoOnline.CustomRender
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewShowAll : ContentView
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create("ItemsSource", typeof(IList), typeof(ListViewShowAll), default(IList),
            propertyChanged: (bindable, oldvalue, newvalue) =>
            {
                var lstview = (ListViewShowAll)bindable;
                lstview.ItemsSource = (IList)newvalue;

            });
        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
                try
                {
                    Task.Factory.StartNew(() =>
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            CellVideoView cellVideoView;
                            BoxView line;
                            foreach (var item in ItemsSource)
                            {
                                cellVideoView = new CellVideoView()
                                {
                                    Margin = new Thickness(40 * App.size_util.scale_x, 0, 40 * App.size_util.scale_x, 0)
                                };
                                line = new BoxView()
                                {
                                    BackgroundColor = App.color_util.font_color_border_gid,
                                    HeightRequest = 1 * App.size_util.scale_min,
                                    HorizontalOptions = LayoutOptions.FillAndExpand
                                };
                                cellVideoView.BindingContext = item;
                                TapGestureRecognizer cellVideoTap = new TapGestureRecognizer();
                                cellVideoTap.Tapped += CellVideoTap_Tapped;
                                cellVideoView.GestureRecognizers.Add(cellVideoTap);
                                lstView.Children.Add(cellVideoView);
                                lstView.Children.Add(line);
                            }
                        });
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

        }

        private void CellVideoTap_Tapped(object sender, EventArgs e)
        {
            try
            {
                var videoInfo = ((CellVideoView)sender).BindingContext as VideoInfoFormatter;
                if (videoInfo != null)
                {
                    // await App.Current.MainPage.Navigation.PushAsync(new VideoPage());
                    var trans = CommonFunc.GetRandomTransitionType();
                    MessagingCenter.Send(this, AppSettings.TransitionMessage, new Tuple<VideoInfoFormatter, TransitionType>(videoInfo, trans));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public ListViewShowAll()
        {
            InitializeComponent();
        }
    }
}