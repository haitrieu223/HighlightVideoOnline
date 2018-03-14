using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HighlightVideoOnline.CustomRender.Videos
{
    /// <summary>
	/// CrossVideoPlayerView is a View which contains a MediaElement to play a video.
	/// </summary>
	public class VideoViewCustom : View
    {

        /// <summary>
        /// The url source of the video.
        /// </summary>
        public static readonly BindableProperty VideoSourceProperty = BindableProperty.Create("VideoSource", typeof(string), typeof(VideoViewCustom), "");

        /// <summary>
        /// The url source of the video.
        /// </summary>
        public string VideoSource
        {
            get
            {
                return (string)GetValue(VideoSourceProperty);
            }
            set
            {
                SetValue(VideoSourceProperty, value);
            }
        }

        /// <summary>
        /// The scale format of the video which is in most cases 16:9 (1.77) or 4:3 (1.33).
        /// </summary>
        public static readonly BindableProperty VideoScaleProperty =
            BindableProperty.Create("VideoScale", typeof(double), typeof(VideoViewCustom), 1.77);

        /// <summary>
        /// The scale format of the video which is in most cases 16:9 (1.77) or 4:3 (1.33).
        /// </summary>
        public double VideoScale
        {
            get
            {
                return (double)GetValue(VideoScaleProperty);
            }
            set
            {
                SetValue(VideoScaleProperty, value);
            }
        }
        public static readonly BindableProperty FileSourceProperty =
            BindableProperty.Create("FileSource", typeof(string), typeof(VideoViewCustom), "");

        public string FileSource
        {
            get { return (string)GetValue(FileSourceProperty); }
            set { SetValue(FileSourceProperty, value); }
        }


        public static readonly BindableProperty IsVisibleNavigationProperty =
          BindableProperty.Create("IsVisibleNavigation", typeof(bool), typeof(VideoViewCustom), false);

        public Action SetEventShowView { get; set; }
        public Action SetEVentHideView { get; set; }
        public Action SetLeaveView { get; set; }

        public Action<bool> SetFullScreen { get; set; }

        public void GetEventShowView()
        {
            if (SetEventShowView != null)
            {
                SetEventShowView();
            }
        }

        public void GetEventHidView()
        {
            if (SetEVentHideView != null)
            {
                SetEVentHideView();
            }
        }

    }
}
