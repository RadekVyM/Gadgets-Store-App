using GadgetStoreApp.Core;
using GadgetStoreApp.Maui.Views.Pages;

namespace GadgetStoreApp.Maui
{
    public partial class AppShell : SimpleToolkit.SimpleShell.SimpleShell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(PageEnum.ProductDetailPage.ToString(), typeof(ProductDetailPage));
        }
    }
}