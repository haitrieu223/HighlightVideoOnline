using HighlightVideoOnline.CustomRender;
using HighlightVideoOnline.Models.Objects;
using HighlightVideoOnline.Models.Objects.Infos;
using HighlightVideoOnline.Views.CommonView;
using HighlightVideoOnline.Views.MainViews;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HighlightVideoOnline.ViewModels
{
    public class HomeViewModel : BaseContentViewModel
    {

        private List<VideoInfoFormatter> _ListVideo;
        public List<VideoInfoFormatter> ListVideo
        {
            get { return _ListVideo; }
            set
            {
                _ListVideo = value;
                OnPropertyChanged(nameof(ListVideo));
            }
        }

        private ObservableCollection<VideoInfoFormatter> _ListSliderImage;
        public ObservableCollection<VideoInfoFormatter> ListSliderImage
        {
            get { return _ListSliderImage; }
            set
            {
                _ListSliderImage = value;
                OnPropertyChanged(nameof(ListSliderImage));
            }
        }

        public HomeViewModel()
        {
            ListVideo = new List<VideoInfoFormatter>();
            _ListSliderImage = new ObservableCollection<VideoInfoFormatter>();
        }
        

        private IEnumerable<VideoInfoFormatter> InitListView()
        {
            for (int i = 1; i < 10; i++)
            {
                yield return new VideoInfoFormatter()
                {
                    Name = $"Oh yeah {i}",
                    UrlThumbnail = "thumbnaildefault.jpg",
                    Views = 10000,
                    Tag = "WWE"
                };
            }
        }

        public void SetDataDefault()
        {

            Task.Factory.StartNew(async () =>
            {
                _ListSliderImage.Add(new VideoInfoFormatter() { Name = "Item 1", UrlThumbnail = "girl_640_360.jpg" });
                _ListSliderImage.Add(new VideoInfoFormatter() { Name = "Item 2", UrlThumbnail = "girl_640_360.jpg" });
                _ListSliderImage.Add(new VideoInfoFormatter() { Name = "Item 3", UrlThumbnail = "girl_640_360.jpg" });
                _ListSliderImage.Add(new VideoInfoFormatter() { Name = "Item 4", UrlThumbnail = "girl_640_360.jpg" });
                _ListSliderImage.Add(new VideoInfoFormatter() { Name = "Item 5", UrlThumbnail = "girl_640_360.jpg" });
                await Task.Delay(2000);
            });

            Task.Factory.StartNew(() =>
            {
                ListVideo.AddRange(InitListView());
            });
        }
    }
}
