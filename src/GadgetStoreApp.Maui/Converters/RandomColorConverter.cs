using System.Globalization;

namespace GadgetStoreApp.Maui.Converters
{
    public class RandomColorConverter : IValueConverter
    {
        Random random = new Random();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = random.Next(0, 6);

            switch (number)
            {
                case 0:
                    return Color.FromArgb("#FFBA00");
                case 1:
                    return Color.FromArgb("#fd6202");
                case 2:
                    return Color.FromArgb("#90c920");
                case 3:
                    return Color.FromArgb("CA1F3D");
                case 4:
                    return Color.FromArgb("#038dfc");
                case 5:
                    return Color.FromArgb("#20c9b2");
                default:
                    return Color.FromArgb("#FFBA00");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
