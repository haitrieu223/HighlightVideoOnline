using HighlightVideoOnline.Models.Objects;
using HighlightVideoOnline.Models.Objects.Infos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HighlightVideoOnline.ViewModels
{
    public class WatchLaterViewModel : BaseContentViewModel
    {
        private ObservableCollection<VideoInfoFormatter> _ListVideo;
        public ObservableCollection<VideoInfoFormatter> ListVideo
        {
            get { return _ListVideo; }
            set
            {
                _ListVideo = value;
                OnPropertyChanged(nameof(ListVideo));
            }
        }

        public WatchLaterViewModel()
        {
            ListVideo = new ObservableCollection<VideoInfoFormatter>();
        }


        public void SetDataDefault()
        {
            Task.Factory.StartNew(async() => {
                for (int i = 1; i < 10; i++)
                {
                    ListVideo.Add(new VideoInfoFormatter()
                    {
                        Name = $"Oh yeah {i}",
                        UrlThumbnail = "thumbnaildefault.jpg",
                        Views = 10000,
                        Tag = "WWE"
                    });
                    await Task.Delay(200);
                }
            });
        }
    }
}
