using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HighlightVideoOnline.Commons
{
	public partial class CustomResouces : ResourceDictionary
	{
		public CustomResouces ()
		{
            double okmen = 10;
            double mor = 30;
            Thickness marginok = new Thickness(0, 0, 300, 0);
			InitializeComponent ();
            Add("fontlarge", okmen);
            Add("fontnormal", mor);
            Add("margin1", marginok);
        }
	}
}