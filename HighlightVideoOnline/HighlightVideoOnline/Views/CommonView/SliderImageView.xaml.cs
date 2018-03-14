using FFImageLoading.Forms;
using HighlightVideoOnline.Models.Objects;
using HighlightVideoOnline.Models.Objects.Infos;
using HighlightVideoOnline.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HighlightVideoOnline.Views.CommonView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SliderImageView : ContentView
    {
        public static readonly BindableProperty ListItemsProperty = BindableProperty.Create("ListItems", typeof(ObservableCollection<VideoInfoFormatter>), typeof(SliderImageView), default(IList),
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                var view = (SliderImageView)bindable;
                view.ListItems = (ObservableCollection<VideoInfoFormatter>)newValue;

            });
        private int _CurrentPosition = 0;
        public ObservableCollection<VideoInfoFormatter> ListItems
        {
            get { return (ObservableCollection<VideoInfoFormatter>)GetValue(ListItemsProperty); }
            set
            {
                SetValue(ListItemsProperty, value);
                Task.Factory.StartNew(() =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        carouselView.ItemsSource = ListItems;
                        CachedImage imgPositision;
                        int index = 0;
                        foreach (var item in ListItems)
                        {
                            item.IsSelected = index == 0 ? true : false;
                            imgPositision = new CachedImage()
                            {
                                WidthRequest = 36 * App.size_util.scale_min,
                                HeightRequest = 36 * App.size_util.scale_min,
                                VerticalOptions = LayoutOptions.Center
                            };
                            imgPositision.SetBinding(CachedImage.SourceProperty, "ImageRadio");
                            imgPositision.BindingContext = item;
                            stackPositon.Children.Add(imgPositision);
                            index++;
                        }
                        carouselView.PositionSelected += CarouselView_PositionSelected;
                        VideoInfoFormatter nextItem;
                        VideoInfoFormatter lastItem;
                        Device.StartTimer(TimeSpan.FromSeconds(5), () =>
                        {
                            if ((_CurrentPosition + 1) == ListItems.Count)
                            {
                                _CurrentPosition = 0;
                                nextItem = ListItems[0];
                                carouselView.Position = _CurrentPosition;
                                lastItem = ListItems[ListItems.Count - 1];
                            }
                            else
                            {
                                carouselView.Position = _CurrentPosition + 1;
                                nextItem = ListItems[_CurrentPosition + 1];
                                lastItem = ListItems[_CurrentPosition];
                            }
                            ((VideoInfoFormatter)lastItem).IsSelected = false;
                            ((VideoInfoFormatter)nextItem).IsSelected = true;
                            _CurrentPosition++;

                            return true;
                        });
                    });
                });
            }
        }

        private void CarouselView_PositionSelected(object sender, SelectedPositionChangedEventArgs e)
        {
            if ((int)e.SelectedPosition != -1)
            {
                if (ListItems?.Count > 0)
                {
                    var item = ListItems[(int)e.SelectedPosition];
                    var lastItem = ListItems[_CurrentPosition];
                    ((VideoInfoFormatter)lastItem).IsSelected = false;
                    ((VideoInfoFormatter)item).IsSelected = true;
                    _CurrentPosition = (int)e.SelectedPosition;
                }
            }
        }

        public SliderImageView()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}