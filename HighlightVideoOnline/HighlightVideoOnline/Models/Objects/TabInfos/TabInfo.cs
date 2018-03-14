using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HighlightVideoOnline.Models.Objects
{
    public class TabInfo : BaseObjects
    {
        public int Id { get; set; }
        private bool _IsSelected;
        public bool ISelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                OnPropertyChanged(nameof(ISelected));
                OnPropertyChanged(nameof(ColorSelected));
            }
        }

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

        public Color ColorSelected
        {
            get
            {
                if (ISelected)
                {
                    return App.color_util.font_color_icon_selected;
                }
                else
                {
                    return App.color_util.font_color_icon_default;
                }
            }
        }

        public Thickness MarginTopImg
        {
            get
            {
                return new Thickness(0, 10 * App.size_util.scale_min, 0, 0);
            }
        }

        public Color BackGroundTab
        {
            get
            {
                return App.color_util.font_color_bg_tab;
            }
        }

        private bool _IsEffect;
        public bool IsEffect
        {
            get { return _IsEffect; }
            set
            {
                _IsEffect = value;
                OnPropertyChanged(nameof(IsEffect));
            }
        }
        public float BorderRadius
        {
            get
            {
                return 50 * App.size_util.scale_min;
            }
        }

        private float _EffectOpacity = 0.5f;
        public float EffectOpacity
        {
            get
            {
                return _EffectOpacity;
            }
            set
            {
                _EffectOpacity = value;
                OnPropertyChanged(nameof(EffectOpacity));
            }
        }


        public Color EffectColor
        {
            get { return App.color_util.font_color_icon_selected; }
        }

        public View CurrentContentView
        {
            get; set;
        }


        public TabInfo()
        { }
    }
}
