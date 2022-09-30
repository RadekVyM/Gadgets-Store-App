using GadgetStoreApp.Maui.Views.Pages;
using SimpleToolkit.Core;

namespace GadgetStoreApp.Maui.Extensions
{
    public static class PageExtensions
    {
        public static void SetNavigationBarAppearence(this Page page)
        {
            var lightElements = page switch
            {
                HomePage => true,
                ProductDetailPage => false,
                BalancePage => false,
                CartPage => false,
                FavoritesPage => false,
                HelpPage => false,
                ProfilePage => false,
                SettingsPage => false,
                _ => false
            };

#if ANDROID
            page.Window.SetStatusBarAppearance(Colors.Transparent, lightElements);
#endif
        }
    }
}
