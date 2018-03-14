using HighlightVideoOnline.Models.Objects.Infos;
using HighlightVideoOnline.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HighlightVideoOnline
{
   public class DetailDemoPageViewModel : BaseViewModel
    {
        private VideoInfo _Video;
        public VideoInfo Video
        {
            get { return _Video; }
            set
            {
                _Video = value;
                OnPropertyChanged(nameof(Video));
            }
        }

        public ICommand NavToDetailCommand => new Command(NavToDetail);

        private void NavToDetail(object obj)
        {
            App.Current.MainPage.DisplayAlert("OK", "Ok","OK");
        }

        public DetailDemoPageViewModel(VideoInfo video)
        {
            //MessagingCenter.Subscribe<DemoPageViewModel, VideoInfo>(this, "OK", (sende, e) => {
            //    _Video = e;
            //    _Video.Name = "Tau đây";
            //});
                _Video = video;
                _Video.Name = "Tau đây";
        }
    }
}
