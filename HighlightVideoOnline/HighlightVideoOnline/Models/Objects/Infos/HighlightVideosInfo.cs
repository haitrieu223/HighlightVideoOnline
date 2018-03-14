using System;
using System.Collections.Generic;
using System.Text;

namespace HighlightVideoOnline.Models.Objects.Infos
{
    public class HighlightVideosInfo : BaseObjects
    {
        public long Id { get; set; }
        private long _Name;
        public long Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private long _VideoId;
        public long VideoId
        {
            get { return _VideoId; }
            set
            {
                _VideoId = value;
                OnPropertyChanged(nameof(VideoId));
            }
        }

        private string _UrlVideo;
        public string UrlVideo
        {
            get { return _UrlVideo; }
            set
            {
                _UrlVideo = value;
                OnPropertyChanged(nameof(UrlVideo));
            }
        }

        private int _QualityVideoId;
        public int QualityVideoId
        {
            get { return _QualityVideoId; }
            set
            {
                _QualityVideoId = value;
                OnPropertyChanged(nameof(QualityVideoId));
            }
        }

        public HighlightVideosInfo()
        { }
    }
}
