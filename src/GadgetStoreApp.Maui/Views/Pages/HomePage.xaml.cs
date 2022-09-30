using GadgetStoreApp.Core;
using GadgetStoreApp.Maui.Extensions;
using GadgetStoreApp.Maui.Views.Controls;
using SimpleToolkit.Core;

namespace GadgetStoreApp.Maui.Views.Pages
{
    public partial class HomePage : ContentPage
    {
        private const int HeaderHeight = 486;
        
        private double verticalOffset = 0;
        private double defaultWhiteBoxViewOffset => backgroundImage.HeightRequest - whiteBoxView.CornerRadius.TopLeft - rootContentGrid.Padding.Top;
        private float density => (float)DeviceDisplay.MainDisplayInfo.Density;

        private readonly IHomePageViewModel viewModel;

        public HomePage(IHomePageViewModel homePageViewModel)
        {
            InitializeComponent();
            BindingContext = viewModel = homePageViewModel;

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
            rootContentGrid.Padding = new Thickness(0, safeArea.Top + AppBar.AppBarPadding.Top, 0, 0);
            collectionView.Margin = new Thickness(safeArea.Left, 0, safeArea.Right, 0);
        }

        private void HomePageSizeChanged(object sender, EventArgs e)
        {
            backgroundImage.HeightRequest = Height * 0.5d;
            whiteBoxView.HeightRequest = collectionView.Height + whiteBoxView.CornerRadius.BottomLeft;
            whiteBoxView.TranslationY = defaultWhiteBoxViewOffset - verticalOffset < 0 ? 0 : defaultWhiteBoxViewOffset - verticalOffset;
            textStack.Margin = new Thickness(24, defaultWhiteBoxViewOffset - textStack.HeightRequest - 10, 0, 0);
            headerStack.HeightRequest = textStack.Margin.VerticalThickness + HeaderHeight; // Because of a bug on iOS

            UpdateTextOpacities();
        }

        private void CollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            verticalOffset = e.VerticalOffset;

            double offset = defaultWhiteBoxViewOffset - verticalOffset < 0 ? 0 : defaultWhiteBoxViewOffset - verticalOffset;
            whiteBoxView.TranslationY = offset;

            UpdateTextOpacities();
        }

        private void UpdateTextOpacities()
        {
            double firstPosition = textStack.Margin.Top;
            double secondPosition = textStack.Margin.Top + secondText.HeightRequest;
            double thirdPosition = textStack.Margin.Top + secondText.HeightRequest + thirdText.HeightRequest;

            double firstOpacity = firstPosition - verticalOffset <= 0 ? 0 : (firstPosition - verticalOffset) / firstPosition;
            double secondOpacity = secondPosition - verticalOffset <= 0 ? 0 : (secondPosition - verticalOffset) / secondPosition;
            double thirdOpacity = thirdPosition - verticalOffset <= 0 ? 0 : (thirdPosition - verticalOffset) / thirdPosition;

            firstText.Opacity = firstOpacity;
            secondText.Opacity = secondOpacity;
            thirdText.Opacity = thirdOpacity;
        }

        private void ProductContentButtonClicked(object sender, EventArgs e)
        {
            var view = sender as View;

            viewModel.ProductSelectedCommand?.Execute(view.BindingContext);
        }
    }
}
