using HighlightVideoOnline.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace HighlightVideoOnline.Converters
{
    public class RectangleArrayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (parameter != null && parameter is Array)
                {
                    var arrValue = parameter as double[];
                   return new Rectangle(((double)arrValue[0]) * (double)App.size_util.scale_min, ((double)arrValue[1]) * App.size_util.scale_min, 
                       ((double)arrValue[2]) * App.size_util.scale_min, ((double)arrValue[3]) * App.size_util.scale_min);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return new Rectangle();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
