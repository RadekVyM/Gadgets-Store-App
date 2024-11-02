using GadgetStoreApp.Core;
using GadgetStoreApp.Maui.Services;
using GadgetStoreApp.Maui.Views.Pages;
using SimpleToolkit.Core;
using SimpleToolkit.SimpleShell;

namespace GadgetStoreApp.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Gabarito-Black.ttf", "BlackFont");
                fonts.AddFont("Gabarito-Bold.ttf", "BoldFont");
                fonts.AddFont("Gabarito-Regular.ttf", "RegularFont");
            });

        builder.UseSimpleToolkit();
        builder.UseSimpleShell();

        builder.DisplayContentBehindBars();

#if ANDROID
        builder.SetDefaultStatusBarAppearance(Colors.Transparent, true);
        builder.SetDefaultNavigationBarAppearance(Colors.Transparent, false);
#endif

        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<ICartManager, CartManager>();
        builder.Services.AddSingleton<IProductsManager, ProductsManager>();

        // Do not forget to register pages when using DI
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<BalancePage>();
        builder.Services.AddTransient<CartPage>();
        builder.Services.AddTransient<FavoritesPage>();
        builder.Services.AddTransient<HelpPage>();
        builder.Services.AddTransient<SettingsPage>();
        builder.Services.AddTransient<ProductDetailPage>();

        builder.Services.AddTransient<IHomePageViewModel, HomePageViewModel>();
        builder.Services.AddTransient<IProductDetailPageViewModel, ProductDetailPageViewModel>();

        return builder.Build();
    }
}