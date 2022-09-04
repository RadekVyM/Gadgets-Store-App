using GadgetStoreApp.Core;

namespace GadgetStoreApp.Maui.Views.Pages
{
    public partial class ProductDetailPage : ContentPage
    {
        private readonly IProductDetailPageViewModel viewModel;

        public ProductDetailPage(IProductDetailPageViewModel productDetailPageViewModel)
        {
            InitializeComponent();
            BindingContext = viewModel = productDetailPageViewModel;
        }
    }
}
