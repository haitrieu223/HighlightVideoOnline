using System;
using System.Collections.Generic;
using System.Text;

namespace HighlightVideoOnline.Models.Objects.Infos
{
    public class QualityVideoInfo : BaseObjects
    {
        public int Id { get; set; }
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

        public QualityVideoInfo()
        { }
    }
}
