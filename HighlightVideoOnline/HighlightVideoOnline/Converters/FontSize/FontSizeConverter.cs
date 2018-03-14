using HighlightVideoOnline.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace HighlightVideoOnline.Converters
{
    public class FontSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float result = 24f; 
            try
            {
                if(parameter != null)
                {
                    if(parameter is string)
                    {
                        string fontSizeKey = parameter.ToString();
                        switch(fontSizeKey)
                        {
                            case "normal":
                                result = App.size_util.font_size_normal;
                                break;
                            case "title":
                                result = App.size_util.font_size_title;
                                break;
                            case "navigation":
                                result = App.size_util.font_size_navigation;
                                break;
                            default:
                                result = 24f;
                                break;
                        }
                    }
                }
            }catch(Exception ex)
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
