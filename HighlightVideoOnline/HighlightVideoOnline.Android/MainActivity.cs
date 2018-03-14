using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using Xamarin.Forms;

namespace HighlightVideoOnline.Droid
{
    [Activity(Label = "HighlightVideoOnline", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,ScreenOrientation =ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            Window.RequestFeature(WindowFeatures.NoTitle);
            Window.AddFlags(WindowManagerFlags.Fullscreen);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            //Forms.SetFlags("FastRenderers_Experimental");

            float density = Resources.DisplayMetrics.Density;
            float widthScreen = (float)Resources.DisplayMetrics.WidthPixels / density;
            float heightScreen = (float)Resources.DisplayMetrics.HeightPixels / density;
            App.size_util = new Commons.SizeUtil(widthScreen, heightScreen, density, true);
            base.OnCreate(bundle);
            //global::Xamarin.Forms.Forms.SetFlags("FastRenderers_Experimental");
            global::Xamarin.Forms.Forms.Init(this, bundle);
            CachedImageRenderer.Init(true);
            LoadApplication(new App());    
        }
    }
}

