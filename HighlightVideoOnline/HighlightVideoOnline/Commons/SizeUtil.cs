using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace HighlightVideoOnline.Commons
{
    public class SizeUtil : INotifyPropertyChanged
    {
        #region font size
        private float _width_screen;
        public float width_screen
        {
            get { return _width_screen; }
            set
            {
                _width_screen = value;
                OnPropertyChanged(nameof(width_screen));
            }
        }
        public float _height_screen;
        public float height_screen
        {
            get { return _height_screen; }
            set
            {
                _height_screen = value;
                OnPropertyChanged(nameof(height_screen));
            }
        }

        public float density;
        public bool is_portait;


        private float _scale_min;
        public float scale_min
        {
            get { return _scale_min; }
            set
            {
                _scale_min = value;
                OnPropertyChanged(nameof(scale_min));
            }
        }


        public float _scale_x;
        public float scale_x
        {
            get { return _scale_x; }
            set
            {
                _scale_x = value;
                OnPropertyChanged(nameof(scale_x));
            }
        }

        public float _scale_y;
        public float scale_y
        {
            get { return _scale_y; }
            set
            {
                _scale_y = value;
                OnPropertyChanged(nameof(scale_y));
            }
        }

        private float _font_size_normal = 24f;
        public float font_size_normal
        {
            get { return _font_size_normal; }
            set
            {
                _font_size_normal = value;
                OnPropertyChanged(nameof(font_size_normal));
            }
        }

        private float _font_size_title = 30f;
        public float font_size_title
        {
            get { return _font_size_title; }
            set
            {
                _font_size_title = value;
                OnPropertyChanged(nameof(font_size_title));
            }
        }


        private float _font_size_category = 36f;

        public float font_size_category
        {
            get { return _font_size_category; }
            set
            {
                _font_size_category = value;
                OnPropertyChanged(nameof(font_size_category));
            }
        }

        private float _font_size_navigation;

        public float font_size_navigation
        {
            get { return _font_size_navigation; }
            set
            {
                _font_size_navigation = value;
                OnPropertyChanged(nameof(font_size_navigation));
            }
        }
        #endregion      
        public SizeUtil()
        {

        }
        public SizeUtil(float widthScreen, float heightScreen, float _density, bool _isPortrait)
        {
            _width_screen = widthScreen;
            _height_screen = heightScreen;
            density = _density;
            is_portait = _isPortrait;

            if (is_portait)
            {
                if (width_screen > height_screen)
                {
                    _width_screen = heightScreen;
                    _height_screen = widthScreen;
                }
                _scale_x = width_screen / 720f;
                _scale_y = height_screen / 1280f;
                _scale_min = Math.Min(scale_x, scale_y);
            }
            else
            {
                if (height_screen < width_screen)
                {
                    _width_screen = heightScreen;
                    _height_screen = widthScreen;
                }
                _scale_x = width_screen / 1280f;
                _scale_y = height_screen / 720f;
                _scale_min = Math.Min(scale_x, scale_y);
            }
            font_size_normal = 24f * scale_min;
            font_size_title = 30f * scale_min;
            font_size_category = 36f * scale_min;
            font_size_navigation = 40f * scale_min;
        }

        public void ReCalSize(bool _isPortrait)
        {
            is_portait = _isPortrait;
            if (is_portait)
            {
                width_screen = height_screen;
                height_screen = width_screen;
                _scale_x = width_screen / 720f;
                _scale_y = height_screen / 1280f;
                _scale_min = Math.Min(scale_x, scale_y);
            }
            else
            {
                width_screen = height_screen;
                height_screen = width_screen;
                _scale_x = width_screen / 1280f;
                _scale_y = height_screen / 720f;
                _scale_min = Math.Min(scale_x, scale_y);
            }
            font_size_normal = 24f * scale_min;
            font_size_title = 30f * scale_min;
            font_size_category = 36f * scale_min;
            font_size_navigation = 40f * scale_min;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
