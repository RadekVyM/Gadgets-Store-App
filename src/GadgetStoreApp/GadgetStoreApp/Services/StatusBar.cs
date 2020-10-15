using Xamarin.Forms;

namespace GadgetStoreApp
{
    public static class StatusBar
    {
        public static double Height => DependencyService.Get<IStatusBarService>().GetHeight() / Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density;

        public static Thickness Padding => new Thickness(0, Height, 0, 0);
    }
}
