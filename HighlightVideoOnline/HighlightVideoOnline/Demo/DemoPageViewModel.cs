using HighlightVideoOnline.Models.Objects.Infos;
using HighlightVideoOnline.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HighlightVideoOnline
{
   public class DemoPageViewModel : BaseViewModel
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

        public void Click()
        {

        }

        public ICommand NavToDetailCommand => new Command(NavToDetail);

   

        private void NavToDetail(object obj)
        {
            var video = obj as VideoInfo;
            var model = new DetailDemoPageViewModel(video);
           // MessagingCenter.Send(this, "OK", video);
            App.Current.MainPage.Navigation.PushAsync(new DetailDemoPage() { BindingContext = model  });
        }

        public DemoPageViewModel()
        {
            _Video = new VideoInfo()
            {
                Name = "Video phim",
                UrlThumbnail = "icon.png"
            };

            
        }
    }
}
