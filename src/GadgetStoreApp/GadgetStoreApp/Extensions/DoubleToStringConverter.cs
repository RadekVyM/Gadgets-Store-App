using System;
using System.Globalization;
using Xamarin.Forms;

namespace GadgetStoreApp
{
    public class DoubleToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double number = (double)value;
            return number.ToString("0.0");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
