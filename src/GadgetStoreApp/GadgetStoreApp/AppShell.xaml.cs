using GadgetStoreApp.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GadgetStoreApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(PageEnum.ProductDetailPage.ToString(), typeof(ProductDetailPage));
            Routing.RegisterRoute(PageEnum.ProfilePage.ToString(), typeof(ProfilePage));
            Routing.RegisterRoute(PageEnum.BalancePage.ToString(), typeof(BalancePage));
            Routing.RegisterRoute(PageEnum.CartPage.ToString(), typeof(CartPage));
            Routing.RegisterRoute(PageEnum.FavoritesPage.ToString(), typeof(FavoritesPage));
            Routing.RegisterRoute(PageEnum.HelpPage.ToString(), typeof(HelpPage));
            Routing.RegisterRoute(PageEnum.SettingsPage.ToString(), typeof(SettingsPage));

            customFlyout.Items.Add(new ShellContent { Route = PageEnum.HomePage.ToString(), ContentTemplate = new DataTemplate(typeof(HomePage)) });
        }

        public bool UpdateStatusBarColour()
        {
            var page = Shell.Current.GetCurrentPage();

            bool darkText = page != PageEnum.HomePage;

            DependencyService.Get<IStatusBarService>().SetLightStatusBar(darkText);

            return darkText;
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
            UpdateStatusBarColour();
        }

        protected override bool OnBackButtonPressed()
        {
            if((CurrentItem as CustomFlyout)?.ReversedFlyout.IsOpen == true)
            {
                (CurrentItem as CustomFlyout)?.ReversedFlyout.CloseAsync();
                return true;
            }
            else
                return base.OnBackButtonPressed();
        }
    }
}