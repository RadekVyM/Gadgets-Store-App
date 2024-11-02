using GadgetStoreApp.Core;
using GadgetStoreApp.Maui.Views.Controls;
using SimpleToolkit.Core;

namespace GadgetStoreApp.Maui.Views.Pages;

public partial class HomePage : ContentPage
{
    private const int VisibleImageHeight = 220;
    
    private double verticalOffset = 0;
    private double defaultWhiteBoxViewOffset => VisibleImageHeight - whiteBoxView.CornerRadius.TopLeft;

    private readonly IHomePageViewModel viewModel;

    public HomePage(IHomePageViewModel homePageViewModel)
    {
        InitializeComponent();
        BindingContext = viewModel = homePageViewModel;

        rootContentGrid.RowDefinitions = new RowDefinitionCollection(new RowDefinition(AppBar.AppBarPadding.Top), new RowDefinition(GridLength.Star));
        headerStack.Padding = new Thickness(0, VisibleImageHeight - firstText.HeightRequest - secondText.HeightRequest - whiteBoxView.CornerRadius.TopLeft, 0, 0);

        SizeChanged += HomePageSizeChanged;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        this.Window.SubscribeToSafeAreaChanges(OnSafeAreaChanged);
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
        this.Window.UnsubscribeFromSafeAreaChanges(OnSafeAreaChanged);
    }

    private void OnSafeAreaChanged(Thickness safeArea)
    {
        rootContentGrid.Padding = new Thickness(0, safeArea.Top, 0, 0);
        collectionView.Margin = new Thickness(safeArea.Left, 0, safeArea.Right, 0);
        footerPaddingContentView.HeightRequest = safeArea.Bottom;
    }

    private void HomePageSizeChanged(object sender, EventArgs e)
    {
        backgroundImage.HeightRequest = VisibleImageHeight + rootContentGrid.Padding.Top + AppBar.AppBarPadding.Top;
        whiteBoxView.HeightRequest = collectionView.Height + whiteBoxView.CornerRadius.BottomLeft;
        whiteBoxView.TranslationY = Math.Min(defaultWhiteBoxViewOffset, Math.Max(defaultWhiteBoxViewOffset - verticalOffset, 0));

        UpdateTextOpacities();
    }

    private void CollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        verticalOffset = e.VerticalOffset;
        System.Diagnostics.Debug.WriteLine($"{verticalOffset} {Math.Min(defaultWhiteBoxViewOffset, Math.Max(defaultWhiteBoxViewOffset - verticalOffset, 0))}");
        whiteBoxView.TranslationY = Math.Min(defaultWhiteBoxViewOffset, Math.Max(defaultWhiteBoxViewOffset - verticalOffset, 0));
        UpdateTextOpacities();
    }

    private void UpdateTextOpacities()
    {
        double firstPosition = headerStack.Padding.Top;
        double secondPosition = headerStack.Padding.Top + secondText.HeightRequest;

        firstText.Opacity = Math.Max(0, (firstPosition - verticalOffset) / firstPosition);
        secondText.Opacity = Math.Max(0, (secondPosition - verticalOffset) / secondPosition);
    }

    private void ProductContentButtonClicked(object sender, EventArgs e)
    {
        var view = sender as View;
        viewModel.ProductSelectedCommand?.Execute(view.BindingContext);
    }

    private void PopularCarouselViewCurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
    {
        if (sender is not CarouselView carousel)
            return;

        var index = carousel.ItemsSource.Cast<object>().ToList().IndexOf(e.CurrentItem);
        popularIndicatorView.MoveTo(index);
    }
}