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

        private void Button_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync("..");
        }
    }
}
