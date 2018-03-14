using HighlightVideoOnline.DependencyServices;
using HighlightVideoOnline.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HighlightVideoOnline
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DemoPage: BaseView<DemoPageViewModel>
	{
		public DemoPage ()
		{
			InitializeComponent ();
            DependencyService.Get<IContentVideoDependency>().DownloadUrl("https://drive.google.com/file/d/1cOp4SMRc2q6ziNZz6BKx9MOHg0fglWJ8/preview");
        }
        
    }
}