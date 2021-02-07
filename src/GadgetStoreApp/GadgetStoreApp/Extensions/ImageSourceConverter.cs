using System;
using System.Globalization;
using Xamarin.Forms;

namespace GadgetStoreApp
{
    public class ImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageSource.FromResource("GadgetStoreApp.Images." + value?.ToString(), typeof(ImageSourceConverter).Assembly);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
