using HighlightVideoOnline.Commons;
using HighlightVideoOnline.Models.Objects;
using HighlightVideoOnline.ViewModels.MainViewModels;
using HighlightVideoOnline.Views.MainViews;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HighlightVideoOnline.ViewModels
{
    public class BottomTabViewModel : BaseViewModel
    {
        private int _CurrentSelectTab = (int)EnumTabMenu.Home;
        public int CurrentSelectTab
        {
            get { return _CurrentSelectTab; }
            set
            {
                _CurrentSelectTab = value;
                OnPropertyChanged(nameof(CurrentSelectTab));
            }
        }
        private Tuple<TabInfo, TabInfo, TabInfo, TabInfo> _TabInfos;
        public Tuple<TabInfo, TabInfo, TabInfo, TabInfo> TabInfos
        {
            get
            {
                return _TabInfos;

            }
            set
            {
                _TabInfos = value;
                OnPropertyChanged(nameof(TabInfos));
            }
        }
        public BottomTabViewModel()
        {
            InitDataDefault();
            MessagingCenter.Subscribe<MainPageViewModel, View>(this, ConstMessage.SET_DEFAULT_MAIN_VIEW, (sender, view) =>
            {
                TabInfos.Item1.CurrentContentView = view;
                MessagingCenter.Unsubscribe<MainPageViewModel, View>(this, ConstMessage.SET_DEFAULT_MAIN_VIEW);
            });
        }

        public void InitDataDefault()
        {
            var home = new TabInfo()
            {
                Id = 1,
                Name = "Home",
                ISelected = true,
                //CurrentContentView = new HomePage().Content
            };

            var history = new TabInfo()
            {
                Id = 2,
                Name = "History",
                ISelected = false,
                //CurrentContentView = new HistoryPage().Content
            };

            var watchlater = new TabInfo()
            {
                Id = 3,
                Name = "Watch later",
                ISelected = false,
                //CurrentContentView = new WatchLaterPage().Content
            };

            var setting = new TabInfo()
            {
                Id = 4,
                Name = "Setting",
                ISelected = false,
                //CurrentContentView = new SettingPage().Content
            };
            _TabInfos = new Tuple<TabInfo, TabInfo, TabInfo, TabInfo>(home, history, watchlater, setting);
        }

        public ICommand TabClick
        {
            get
            {
                return new Command((value) =>
                {
                    this.SetView(value);
                });
            }
        }

        private void SetView(object value)
        {
            try
            {
                switch (value)
                {
                    case (int)EnumTabMenu.Home:
                        SetLastTab(CurrentSelectTab);
                        CurrentSelectTab = (int)value;
                        TabInfos.Item1.ISelected = true;
                        UnTouch((int)value);
                        if (TabInfos.Item1.CurrentContentView == null)
                            TabInfos.Item1.CurrentContentView = new HomePage();
                        this.SendMessageCenter(TabInfos.Item1.CurrentContentView);
                        break;
                    case (int)EnumTabMenu.History:
                        SetLastTab(CurrentSelectTab);
                        CurrentSelectTab = (int)value;
                        TabInfos.Item2.ISelected = true;
                        UnTouch((int)value);
                        if (TabInfos.Item2.CurrentContentView == null)
                            TabInfos.Item2.CurrentContentView = new HistoryPage();
                        this.SendMessageCenter(TabInfos.Item2.CurrentContentView);
                        break;
                    case (int)EnumTabMenu.WatchLater:
                        SetLastTab(CurrentSelectTab);
                        CurrentSelectTab = (int)value;
                        TabInfos.Item3.ISelected = true;
                        UnTouch((int)value);
                        if (TabInfos.Item3.CurrentContentView == null)
                            TabInfos.Item3.CurrentContentView = new WatchLaterPage();                      
                        this.SendMessageCenter(TabInfos.Item3.CurrentContentView);
                        break;
                    case (int)EnumTabMenu.Setting:
                        SetLastTab(CurrentSelectTab);
                        CurrentSelectTab = (int)value;
                        TabInfos.Item4.ISelected = true;
                        UnTouch((int)value);
                        if (TabInfos.Item4.CurrentContentView == null)
                            TabInfos.Item4.CurrentContentView = new SettingPage();
                        this.SendMessageCenter(TabInfos.Item4.CurrentContentView);
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        // Create effect when touch tab
        private async void UnTouch(int value)
        {
            try
            {
                // 0.5 opacity , 100f is 100 percent
                var percent = (0.5f / 100f) * 3;
                switch (value)
                {
                    case (int)EnumTabMenu.Home:
                        TabInfos.Item1.IsEffect = true;
                        for (int i = 1; i < 30; i++)
                        {
                            TabInfos.Item1.EffectOpacity = TabInfos.Item1.EffectOpacity - percent;
                            await Task.Delay(1);
                        }
                        TabInfos.Item1.IsEffect = false;
                        TabInfos.Item1.EffectOpacity = 0.5f;
                        break;
                    case (int)EnumTabMenu.History:
                        TabInfos.Item2.IsEffect = true;
                        for (int i = 1; i < 30; i++)
                        {
                            TabInfos.Item2.EffectOpacity = TabInfos.Item2.EffectOpacity - percent;
                            await Task.Delay(1);
                        }
                        TabInfos.Item2.IsEffect = false;
                        TabInfos.Item2.EffectOpacity = 0.5f;
                        break;
                    case (int)EnumTabMenu.WatchLater:
                        TabInfos.Item3.IsEffect = true;
                        for (int i = 1; i < 30; i++)
                        {
                            TabInfos.Item3.EffectOpacity = TabInfos.Item3.EffectOpacity - percent;
                            await Task.Delay(1);
                        }
                        TabInfos.Item3.IsEffect = false;
                        TabInfos.Item3.EffectOpacity = 0.5f;
                        break;
                    case (int)EnumTabMenu.Setting:
                        TabInfos.Item4.IsEffect = true;
                        for (int i = 1; i < 30; i++)
                        {
                            TabInfos.Item4.EffectOpacity = TabInfos.Item4.EffectOpacity - percent;
                            await Task.Delay(1);
                        }
                        TabInfos.Item4.IsEffect = false;
                        TabInfos.Item4.EffectOpacity = 0.5f;
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        //Set view when touch
        private void SendMessageCenter(View view)
        {
            try
            {
                view.TranslationX = -720 * App.size_util.scale_x;
                MessagingCenter.Send<BottomTabViewModel, View>(this, ConstMessage.SET_MAIN_VIEW, view);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        // Set unselect when leave tab
        public void SetLastTab(int value)
        {
            switch (value)
            {
                case (int)EnumTabMenu.Home:
                    TabInfos.Item1.ISelected = false;
                    break;
                case (int)EnumTabMenu.History:
                    TabInfos.Item2.ISelected = false;
                    break;
                case (int)EnumTabMenu.WatchLater:
                    TabInfos.Item3.ISelected = false;
                    break;
                case (int)EnumTabMenu.Setting:
                    TabInfos.Item4.ISelected = false;
                    break;
            }
        }
    }
}
