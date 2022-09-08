using GadgetStoreApp.Core;
using System.Globalization;

namespace GadgetStoreApp.Maui.Converters
{
    public class FeatureEnumToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FeatureEnum feature = (FeatureEnum)value;

            return feature switch
            {
                FeatureEnum.BatteryEndurance => "battery_icon.png",
                FeatureEnum.Bluetooth => "bluetooth_icon.png",
                FeatureEnum.RandomSpec => "speaker_icon.png",
                FeatureEnum.UnderwaterEndurance => "drop_icon.png",
                _ => ""
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
