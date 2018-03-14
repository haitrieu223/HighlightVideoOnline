using HighlightVideoOnline.Commons;
using HighlightVideoOnline.CustomRender.Pages;
using HighlightVideoOnline.ViewModels.MainViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;
using Xamarin.Forms;

namespace HighlightVideoOnline
{
	public partial class App : Application
	{
		public static SizeUtil size_util;
        public static ColorUtil color_util;
        public static IUnityContainer unityContainer;

        public App ()
		{
            unityContainer = new UnityContainer();
            unityContainer.RegisterType<MainPageViewModel>();
            color_util = new ColorUtil();
			InitializeComponent();
            var mainPage = new TransitionNavigationPage(new HighlightVideoOnline.DemoPage());          
            MainPage = mainPage;           
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
           

        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
