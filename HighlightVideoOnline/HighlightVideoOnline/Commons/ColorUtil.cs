using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace HighlightVideoOnline.Commons
{
    public class ColorUtil : INotifyPropertyChanged
    {
        #region font color
        private Color _font_color_background_normal = Color.FromHex("#e3e7ea");
        public Color font_color_background_normal
        {
            get { return _font_color_background_normal; }
            set
            {
                _font_color_background_normal = value;
                OnPropertyChanged(nameof(font_color_background_normal));
            }
        }
        private Color _font_color_background_row_page = Color.FromHex("#ecf0f1");
        public Color font_color_background_row_page
        {
            get { return _font_color_background_row_page; }
            set
            {
                _font_color_background_row_page = value;
                OnPropertyChanged(nameof(font_color_background_row_page));
            }
        }

        private Color _font_color_line = Color.FromHex("#91ca47");
        public Color font_color_line
        {
            get { return _font_color_line; }
            set
            {
                _font_color_line = value;
                OnPropertyChanged(nameof(font_color_line));
            }
        }

        private Color _font_color_white = Color.White;
        public Color font_color_white
        {
            get { return _font_color_white; }
            set
            {
                _font_color_white = value;
                OnPropertyChanged(nameof(font_color_white));
            }
        }

        private Color _font_color_black = Color.Black;
        public Color font_color_black
        {
            get { return _font_color_black; }
            set
            {
                _font_color_black = value;
                OnPropertyChanged(nameof(font_color_black));
            }
        }

        private Color _font_color_border_gid = Color.FromHex("#dbdbdb");
        public Color font_color_border_gid
        {
            get { return _font_color_border_gid; }
            set
            {
                _font_color_border_gid = value;
                OnPropertyChanged(nameof(font_color_border_gid));
            }
        }


        private Color _font_color_icon_default = Color.FromHex("#3f3f3f");
        public  Color font_color_icon_default
        {
            get { return _font_color_icon_default; }
            set
            {
                _font_color_icon_default = value;
                OnPropertyChanged(nameof(font_color_icon_default));
            }
        }

        private Color _font_color_icon_selected = Color.OrangeRed;
        public Color font_color_icon_selected
        {
            get { return _font_color_icon_selected; }
            set
            {
                _font_color_icon_selected = value;
                OnPropertyChanged(nameof(font_color_icon_selected));
            }
        }
        
            private Color _font_color_bg_tab = Color.FromHex("#f7f7f7");
        //private Color _font_color_bg_tab = Color.FromHex("#f2f2f2");
        public Color font_color_bg_tab
        {
            get { return _font_color_bg_tab; }
            set
            {
                _font_color_bg_tab = value;
                OnPropertyChanged(nameof(font_color_bg_tab));
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
