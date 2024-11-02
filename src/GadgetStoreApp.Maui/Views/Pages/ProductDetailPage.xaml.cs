using GadgetStoreApp.Core;
using GadgetStoreApp.Maui.Views.Controls;
using SimpleToolkit.Core;

namespace GadgetStoreApp.Maui.Views.Pages;

public partial class ProductDetailPage : ContentPage
{
    private readonly IProductDetailPageViewModel viewModel;


    public ProductDetailPage(IProductDetailPageViewModel productDetailPageViewModel)
    {
        InitializeComponent();
        BindingContext = viewModel = productDetailPageViewModel;

        Loaded += ProductDetailPageLoaded;
        Unloaded += ProductDetailPageUnloaded;
    }


    private void ProductDetailPageLoaded(object sender, EventArgs e)
    {
        this.Window.SubscribeToSafeAreaChanges(OnSafeAreaChanged);
    }

    private void ProductDetailPageUnloaded(object sender, EventArgs e)
    {
        this.Window.UnsubscribeFromSafeAreaChanges(OnSafeAreaChanged);
    }

    private void OnSafeAreaChanged(Thickness safeArea)
    {
        rootGrid.Margin = new Thickness(0, safeArea.Top + AppBar.AppBarPadding.Top, 0, 0);
        imagesRootGrid.Margin = new Thickness(safeArea.Left, 0, safeArea.Right, 0);
        specsRootGrid.Margin = new Thickness(safeArea.Left, 0, safeArea.Right, safeArea.Bottom);
        addToCartContainer.Padding = new Thickness(safeArea.Left, 0, safeArea.Right, safeArea.Bottom);
    }

    private void ImagesCollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
    {
#if IOS || MACCATALYST
        var index = e.CenterItemIndex;
#else
        var index = e.CenterItemIndex - 1;
#endif

        indicatorView.MoveTo(index);
    }

    private void FavoriteButtonClicked(object sender, EventArgs e)
    {
        viewModel.FavoriteCommand?.Execute(null);
    }

    private void AddToCartButtonClicked(object sender, EventArgs e)
    {
        viewModel.AddToCartCommand?.Execute(viewModel.Product);
    }
}