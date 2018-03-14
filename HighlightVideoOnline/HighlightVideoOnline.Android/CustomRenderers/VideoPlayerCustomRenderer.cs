
using Android.App;
using Android.Content;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content.Res;
using HighlightVideoOnline.Droid.CustomRenderers;
using HighlightVideoOnline.CustomRender.Videos;
using Android.OS;
using Android.Media;
using Android.Net;
using System.Net;

[assembly: ExportRenderer(typeof(VideoViewCustom), typeof(VideoViewRenderer))]
namespace HighlightVideoOnline.Droid.CustomRenderers
{

    public class VideoViewRenderer : ViewRenderer<VideoViewCustom, Android.Views.View>
    {
        public VideoViewRenderer(Context context) : base(context)
        {

        }

        //ProgressDialog progressDialog;
        protected override void OnElementChanged(ElementChangedEventArgs<VideoViewCustom> e)
        {
            base.OnElementChanged(e);
            try
            {
                base.OnElementChanged(e);
                var activity = Context as Activity;
                activity.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
                var crossVideoPlayerView = Element as VideoViewCustom;

                if ((crossVideoPlayerView != null) && (e.OldElement == null))
                {
                    var metrics = Resources.DisplayMetrics;
                    var videoView = new VideoView(activity);
                    var mediaController = new MediaController(activity);
                    mediaController.SetAnchorView(videoView);
                    videoView.SetMediaController(mediaController);
                    videoView.SetVideoPath(e.NewElement.VideoSource);

                    videoView.Touch += (sender, videoEvent) =>
                    {
                        if (!(videoEvent.Event.Action == Android.Views.MotionEventActions.Down))
                            return;
                        if (!mediaController.IsShown)
                        {
                            mediaController.Show();
                            crossVideoPlayerView.GetEventShowView();
                        }
                        else
                        {
                            mediaController.Hide();
                            crossVideoPlayerView.GetEventHidView();
                        }
                    };

                    //progressDialog = new ProgressDialog(Context);
                    //progressDialog.Indeterminate = true;
                    //progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
                    //progressDialog.SetMessage("Contacting server. Please wait...");
                    //progressDialog.SetCancelable(false);
                    //progressDialog.Show();

                    videoView.Prepared += (obj, args) =>
                    {
                        var MyMediaPlayer = obj as MediaPlayer;
                        MyMediaPlayer.Prepared += (Prepared_obj, Prepared_args) =>
                        {

                            //Insert Prepared Code Here
                            var tx = "ok";
                        };
                        MyMediaPlayer.Completion += (Completion_obj, Completion_args) =>
                        {
                            //Insert Completion Code Here
                        };
                        MyMediaPlayer.Error += (Error_obj, Error_args) =>
                        {
                            //Insert Error Code Here
                           // progressDialog.Show();
                        };

                        bool IsFirstShow = true;

                        MyMediaPlayer.BufferingUpdate += (bfObj, bfPro) =>
                        {
                            if (IsFirstShow)
                            {
                                //progressDialog.Dismiss();
                                IsFirstShow = false;
                            }
                            else if (!MyMediaPlayer.IsPlaying)
                            {

                            }
                            //else if (!IsConnected)
                            //{
                            //    progressDialog.Show();
                            //    IsFirstShow = false;
                            //}
                            //else if (!CheckInternetConnection())
                            //{
                            //    progressDialog.Show();
                            //    IsFirstShow = false;
                            //}
                            else
                            {
                                IsFirstShow = true;
                            }
                        };


                        long duration = MyMediaPlayer.Duration / 1000;
                        long hours = duration / 3600;
                        long minutes = (duration - hours * 3600) / 60;
                        long seconds = duration - (hours * 3600 + minutes * 60);
                    };

                    crossVideoPlayerView.SetLeaveView += () =>
                        {
                            activity.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
                            activity.RequestedOrientation = Android.Content.PM.ScreenOrientation.Locked;
                        };
                    crossVideoPlayerView.SetFullScreen += (IsFullScreen) =>
                    {
                        if (IsFullScreen)
                        {
                            activity.RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;
                            activity.RequestedOrientation = Android.Content.PM.ScreenOrientation.Locked;
                        }
                        else
                        {
                            activity.RequestedOrientation = Android.Content.PM.ScreenOrientation.Portrait;
                            activity.RequestedOrientation = Android.Content.PM.ScreenOrientation.Locked;
                        }
                    };

                    videoView.Start();
                    SetNativeControl(videoView);
                }
            }
            catch (System.Exception)
            {

            }
        }

        public bool CheckInternetConnection()
        {
            string CheckUrl = "http://google.com";

            try
            {
                HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(CheckUrl);
                iNetRequest.Timeout = 5000;
                WebResponse iNetResponse = iNetRequest.GetResponse();
                iNetResponse.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            VideoViewCustom video = (VideoViewCustom)sender;
            if (video.ClassId == "10")
            {
                var activity = Context as Activity;
                activity.RequestedOrientation = Android.Content.PM.ScreenOrientation.Landscape;
            }
        }


    }

}