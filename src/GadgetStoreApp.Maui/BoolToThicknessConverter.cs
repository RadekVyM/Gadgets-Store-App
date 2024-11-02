using System.Globalization;

namespace GadgetStoreApp.Maui;

public class BoolToThicknessConverter : IValueConverter
{
    public Thickness True { get; set; }
    public Thickness False { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is true ?
            True :
            False;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}