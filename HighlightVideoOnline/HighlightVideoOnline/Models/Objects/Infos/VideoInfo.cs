using System;
using System.Collections.Generic;
using System.Text;

namespace HighlightVideoOnline.Models.Objects.Infos
{
    public class VideoInfo : BaseObjects
    {
        public long Id { get; set; }
               
        
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }       

        private string _UrlTrailer;
        public string UrlTrailer
        {
            get { return _UrlTrailer; }
            set
            {
                _UrlTrailer = value;
                OnPropertyChanged(nameof(UrlTrailer));
            }
        }

        private string _UrlThumbnail;
        public string UrlThumbnail
        {
            get { return _UrlThumbnail; }
            set
            {
                _UrlThumbnail = value;
                OnPropertyChanged(nameof(UrlThumbnail));
            }
        }

      
        private long _Views;
        public long Views
        {
            get { return _Views; }
            set
            {
                _Views = value;
                OnPropertyChanged(nameof(Views));
            }
        }
        
        private DateTime? _ReleaseDate;
        public DateTime? ReleaseDate
        {
            get { return _ReleaseDate; }
            set
            {
                _ReleaseDate = value;
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }       
        

        private string _Tag;
        public string Tag
        {
            get
            {
                return _Tag;
            }
            set
            {
                _Tag = value;
                OnPropertyChanged(nameof(Tag));
            }
        }

        private bool _IsSelected;
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                OnPropertyChanged(nameof(IsSelected));
                OnPropertyChanged(nameof(ImageRadio));
            }
        }

        public string ImageRadio
        {
            get
            {
                if(IsSelected)
                {
                    return "ic_radio_button_checked_black_24dp.png";
                }else
                {
                    return "ic_radio_button_unchecked_black_24dp.png";
                }
            }
        }

        public VideoInfo()
        {

        }

    }
}
