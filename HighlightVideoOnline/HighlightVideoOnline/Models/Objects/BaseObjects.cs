using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HighlightVideoOnline.Models.Objects
{
    public class BaseObjects : INotifyPropertyChanged
    {
        private int _SortOrder;
        public int SortOrder
        {
            get
            {
                return _SortOrder;
            }
            set
            {
                _SortOrder = value;
                OnPropertyChanged(nameof(SortOrder));
            }
        }

        private DateTime? _UpdateTime;
        public DateTime? UpdateTime
        {
            get { return _UpdateTime; }
            set
            {
                _UpdateTime = value;
                OnPropertyChanged(nameof(UpdateTime));
            }
        }

        private DateTime? _CreateTime;
        public DateTime? CreateTime
        {
            get { return _CreateTime; }
            set
            {
                _CreateTime = value;
                OnPropertyChanged(nameof(CreateTime));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
           return MemberwiseClone();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
