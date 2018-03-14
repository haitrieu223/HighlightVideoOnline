using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HighlightVideoOnline.Views.Videos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPage : ContentPage
    {
        public VideoPage()
        {
            InitializeComponent();
            videoViewCustom.SetEVentHideView += GetEventHideView;
            videoViewCustom.SetEventShowView += GetEventShowView;

            AbsoluteLayout.SetLayoutBounds(videoViewCustom, new Rectangle(0, 0, 720 * App.size_util.scale_x, ((720 * App.size_util.scale_x) * 9) / 16));
            AbsoluteLayout.SetLayoutFlags(videoViewCustom, AbsoluteLayoutFlags.None);

            imgBack.Margin = new Thickness(0, 25 * App.size_util.scale_min, 0, 25 * App.size_util.scale_min);
            AbsoluteLayout.SetLayoutBounds(gridNavigation, new Rectangle(0, 0, 720 * App.size_util.scale_x, 104 * App.size_util.scale_min));
            AbsoluteLayout.SetLayoutFlags(gridNavigation, AbsoluteLayoutFlags.None);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }

        private void GetEventHideView()
        {
            gridNavigation.IsVisible = false;
        }
        private void GetEventShowView()
        {
            SetShowGrid();
        }

        public async void SetShowGrid()
        {
            gridNavigation.IsVisible = true;
            await Task.Delay(3000);
            gridNavigation.IsVisible = false;
        }

        private bool IsFullScreen = true, IsLeave = false;

        public void imgFullScreenTap_Tapped(object sender, EventArgs e)
        {

            if (IsFullScreen)
            {
                AbsoluteLayout.SetLayoutBounds(videoViewCustom, new Rectangle(0, 0, 1280 * App.size_util.scale_x, 1));
                AbsoluteLayout.SetLayoutFlags(videoViewCustom, AbsoluteLayoutFlags.HeightProportional);

                AbsoluteLayout.SetLayoutBounds(gridNavigation, new Rectangle(0, 0, 1, 104 * App.size_util.scale_min));
                AbsoluteLayout.SetLayoutFlags(gridNavigation, AbsoluteLayoutFlags.WidthProportional);
                colTitle.Width = 1200 * App.size_util.scale_min;
            }
            else
            {
                AbsoluteLayout.SetLayoutBounds(videoViewCustom, new Rectangle(0, 0, 720 * App.size_util.scale_x, ((720 * App.size_util.scale_x) * 9) / 16));
                AbsoluteLayout.SetLayoutFlags(videoViewCustom, AbsoluteLayoutFlags.None);

                colTitle.Width = 640 * App.size_util.scale_min;
                AbsoluteLayout.SetLayoutBounds(gridNavigation, new Rectangle(0, 0, 720 * App.size_util.scale_x, 104 * App.size_util.scale_min));
                AbsoluteLayout.SetLayoutFlags(gridNavigation, AbsoluteLayoutFlags.None);
            }
            videoViewCustom.SetFullScreen(IsFullScreen);
            IsFullScreen = !IsFullScreen;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (!IsLeave)
            {
                if (IsFullScreen)
                {
                    AbsoluteLayout.SetLayoutBounds(videoViewCustom, new Rectangle(0, 0, 1280 * App.size_util.scale_x, 1));
                    AbsoluteLayout.SetLayoutFlags(videoViewCustom, AbsoluteLayoutFlags.HeightProportional);

                    AbsoluteLayout.SetLayoutBounds(gridNavigation, new Rectangle(0, 0, 1, 104 * App.size_util.scale_min));
                    AbsoluteLayout.SetLayoutFlags(gridNavigation, AbsoluteLayoutFlags.WidthProportional);
                    colTitle.Width = 1200 * App.size_util.scale_min;
                }
                else
                {
                    AbsoluteLayout.SetLayoutBounds(videoViewCustom, new Rectangle(0, 0, 720 * App.size_util.scale_x, ((720 * App.size_util.scale_x) * 9) / 16));
                    AbsoluteLayout.SetLayoutFlags(videoViewCustom, AbsoluteLayoutFlags.None);

                    colTitle.Width = 640 * App.size_util.scale_min;
                    AbsoluteLayout.SetLayoutBounds(gridNavigation, new Rectangle(0, 0, 720 * App.size_util.scale_x, 104 * App.size_util.scale_min));
                    AbsoluteLayout.SetLayoutFlags(gridNavigation, AbsoluteLayoutFlags.None);
                }
                videoViewCustom.SetFullScreen(IsFullScreen);
                IsFullScreen = !IsFullScreen;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            IsLeave = true;
            videoViewCustom.SetLeaveView();
            return base.OnBackButtonPressed();            
        }

        public async void stackBackTap_Tapped(object sender, EventArgs e)
        {
            IsLeave = true;
            videoViewCustom.SetLeaveView();
            await Navigation.PopAsync();
        }
    }
}