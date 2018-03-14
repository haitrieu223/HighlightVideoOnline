using System;
using System.Collections.Generic;
using System.Text;

namespace HighlightVideoOnline.Models.Objects.Infos
{
    public class CommentInfo : BaseObjects
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

        private string _Sender;
        public string Sender
        {
            get { return _Sender; }
            set
            {
                _Sender = value;
                OnPropertyChanged(nameof(Sender));
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
        public CommentInfo()
        {

        }
    }
}
