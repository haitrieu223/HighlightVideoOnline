using HighlightVideoOnline.Commons;
using HighlightVideoOnline.Models.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HighlightVideoOnline.ViewModels.CommonViewModels
{
    public class MenuBarViewModels : BaseViewModel
    {
        private Tuple<TabInfo, TabInfo, TabInfo, TabInfo> _TabInfos;
        public Tuple<TabInfo, TabInfo, TabInfo, TabInfo> TabInfos
        {
            get { return _TabInfos; }
            set
            {
                _TabInfos = value;
                OnPropertyChanged(nameof(TabInfos));
            }
        }

        private Thickness _MarginTop = new Thickness(0, 20 * App.size_util.scale_min, 0, 0);
        public Thickness MarginTop
        {
            get
            {
                return _MarginTop;
            }
            set
            {
                _MarginTop = value;
                OnPropertyChanged(nameof(MarginTop));
            }
        }

        public void SetTabInfoDefault()
        {
            TabInfo tab1 = new TabInfo()
            {
                Id = (int)EnumTypeVideo.Wwe,
                Name = "WWE"
            };
            TabInfo tab2 = new TabInfo()
            {
                Id = (int)EnumTypeVideo.Soccer,
                Name = "Soccer"
            };

            TabInfo tab3 = new TabInfo()
            {
                Id = (int)EnumTypeVideo.Game,
                Name = "Game"
            };

            TabInfo tab4 = new TabInfo()
            {
                Id = (int)EnumTypeVideo.Mma,
                Name = "MMA"
            };
            _TabInfos = new Tuple<TabInfo, TabInfo, TabInfo, TabInfo>(tab1, tab2, tab3, tab4);
        }

        public MenuBarViewModels()
        {

        }
    }
}
