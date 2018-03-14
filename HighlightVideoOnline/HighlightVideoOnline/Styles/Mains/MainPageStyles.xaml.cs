using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HighlightVideoOnline.Styles
{
	public partial class MainPageStyles : ResourceDictionary
	{
		public MainPageStyles ()
		{
            float stackContentHeight = 1180 * App.size_util.scale_y;
            float colSpaceLeft = 40 * App.size_util.scale_x; 
            InitializeComponent();
            Add("stackContentHeight", stackContentHeight);
            Add("colSpaceLeft", colSpaceLeft);

        }
	}
}