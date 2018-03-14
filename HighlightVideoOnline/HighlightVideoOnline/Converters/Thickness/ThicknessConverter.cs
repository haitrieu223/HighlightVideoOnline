using HighlightVideoOnline.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace HighlightVideoOnline.Converters
{
    public class ThicknessConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (parameter != null)
                {
                    float paddingParam = System.Convert.ToInt32(parameter);
                    return new Thickness(paddingParam * App.size_util.scale_min, paddingParam * App.size_util.scale_min, paddingParam * App.size_util.scale_min, paddingParam * App.size_util.scale_min);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return new Thickness();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
