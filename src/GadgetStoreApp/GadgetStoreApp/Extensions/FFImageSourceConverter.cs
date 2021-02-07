using FFImageLoading.Forms;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace GadgetStoreApp
{
    public class FFImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new EmbeddedResourceImageSource("GadgetStoreApp.Images." + value?.ToString(), typeof(FFImageSourceConverter).Assembly);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
