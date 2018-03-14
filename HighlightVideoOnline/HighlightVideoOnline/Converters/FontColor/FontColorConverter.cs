using HighlightVideoOnline.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace HighlightVideoOnline.Converters
{
    public class FontColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color result = Color.Default;
            try
            {
                if (parameter != null)
                {
                    if (parameter is string)
                    {
                        string fontColorKey = parameter.ToString();
                        switch (fontColorKey)
                        {
                            case "white":
                                result = App.color_util.font_color_white;
                                break;
                            case "black":
                                result = App.color_util.font_color_black;
                                break;
                            case "background_normal":
                                result = App.color_util.font_color_background_normal;
                                break;
                            case "background_row_page":
                                result = App.color_util.font_color_background_row_page;
                                break;
                            case "line_normal":
                                result = App.color_util.font_color_line;
                                break;
                            case "font_color_border_gid":
                                result = App.color_util.font_color_border_gid;
                                break;
                            default:
                                result = Color.Default;
                                break;
                        }
                    }
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
