using GadgetStoreApp.Core;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace GadgetStoreApp
{
    public class FeatureEnumToPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FeatureEnum feature = (FeatureEnum)value;

            string path = "";

            switch(feature)
            {
                case FeatureEnum.BatteryEndurance:
                    path = App.Current.Resources.GetValue<string>("BatteryPath");
                    break;
                case FeatureEnum.Bluetooth:
                    path = App.Current.Resources.GetValue<string>("BluetoothPath");
                    break;
                case FeatureEnum.RandomSpec:
                    path = App.Current.Resources.GetValue<string>("SpeakerPath");
                    break;
                case FeatureEnum.UnderwaterEndurance:
                    path = App.Current.Resources.GetValue<string>("WaterDropPath");
                    break;
            }

            return path;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
