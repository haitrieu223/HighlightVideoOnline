using System;
using System.Collections.Generic;
using System.Text;

namespace HighlightVideoOnline.Models.Objects.Infos
{
    // Một video có thể thuộc nhiều loại danh mục phim
    public class CategoryVideosInfo : BaseObjects
    {
        public long Id { get; set; }
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

        private long _CategoryId;
        public long CategoryId
        {
            get { return _CategoryId; }
            set
            {
                _CategoryId = value;
                OnPropertyChanged(nameof(CategoryId));
            }
        }

        public CategoryVideosInfo()
        { }
    }
}
