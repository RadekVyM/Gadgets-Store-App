using System;
using System.Globalization;
using Xamarin.Forms;

namespace GadgetStoreApp
{
    public class RandomColourConverter : IValueConverter
    {
        Random random = new Random();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = random.Next(0, 6);

            switch(number)
            {
                case 0:
                    return Color.FromHex("#FFBA00");
                case 1:
                    return Color.FromHex("#fd6202");
                case 2:
                    return Color.FromHex("#90c920");
                case 3:
                    return Color.FromHex("CA1F3D");
                case 4:
                    return Color.FromHex("#038dfc");
                case 5:
                    return Color.FromHex("#20c9b2");
                default:
                    return Color.FromHex("#FFBA00");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
