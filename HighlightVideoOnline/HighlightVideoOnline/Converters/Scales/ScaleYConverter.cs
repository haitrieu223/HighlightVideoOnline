using HighlightVideoOnline.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace HighlightVideoOnline.Converters
{
    public class ScaleYConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float result = 0;
            try
            {
                if (parameter != null && parameter is string)
                {
                    var scaleValue = System.Convert.ToInt32(parameter);
                    result = scaleValue * App.size_util.scale_y;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
