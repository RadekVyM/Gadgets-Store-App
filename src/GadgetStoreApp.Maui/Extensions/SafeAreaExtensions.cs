#if IOS
using UIKit;
#endif

namespace GadgetStoreApp.Maui.Extensions
{
    public static class SafeAreaExtensions
    {
        public static Thickness GetSafeAreaInsets(this Window window)
        {
#if IOS
            var uiWindow = window.Handler.PlatformView as UIWindow;
            var insets = new Thickness(uiWindow.SafeAreaInsets.Left, uiWindow.SafeAreaInsets.Top, uiWindow.SafeAreaInsets.Right, uiWindow.SafeAreaInsets.Bottom);

            return insets;
#endif

            return new Thickness(0);
        }
    }
}
