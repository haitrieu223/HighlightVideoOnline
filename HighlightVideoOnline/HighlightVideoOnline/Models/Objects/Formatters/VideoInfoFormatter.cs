using HighlightVideoOnline.Models.Objects.Infos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HighlightVideoOnline.Models.Objects
{
    public class VideoInfoFormatter : VideoInfo
    {
        public string UrlThumbnailHtml
        {
            get
            {
                return $"htpps://{UrlThumbnail}";
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            switch (propertyName)
            {
                case nameof(UrlThumbnail):
                    OnPropertyChanged(UrlThumbnailHtml);
                    break;
            }
        }
    }
}
