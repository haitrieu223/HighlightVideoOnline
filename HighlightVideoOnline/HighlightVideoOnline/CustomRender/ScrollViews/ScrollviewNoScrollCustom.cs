using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HighlightVideoOnline.CustomRender
{
    public class ScrollviewNoScrollCustom : ScrollView
    {
        public static readonly BindableProperty ScrollChangedProperty = BindableProperty.Create(nameof(ScrollChanged), typeof(Command), typeof(ScrollviewNoScrollCustom));
        public Command ScrollChanged
        {
            get { return (Command)GetValue(ScrollChangedProperty); }
            set
            {
                SetValue(ScrollChangedProperty, value);
            }
        }
        private void SetEventScrolled(object sender, ScrolledEventArgs e)
        {
            try
            {
                if (ScrollChanged != null)
                {
                    ScrollChanged.Execute(new Tuple<double, double>(e.ScrollX, e.ScrollY));
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
        }
        public ScrollviewNoScrollCustom()
        {
            Scrolled += ScrollviewNoScrollCustom_Scrolled;
        }

        private void ScrollviewNoScrollCustom_Scrolled(object sender, ScrolledEventArgs e)
        {
            try
            {
                SetEventScrolled(sender, e);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
