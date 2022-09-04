using GadgetStoreApp.Core;
using GadgetStoreApp.Maui.Views.Controls;

namespace GadgetStoreApp.Maui.Views.Pages
{
    public partial class HomePage : ContentPage
    {
        double verticalOffset = 0;
        double defaultWhiteBoxViewOffset => backgroundImage.HeightRequest - whiteBoxView.CornerRadius.TopLeft - AppBar.AppBarPadding.Top;
        float density => (float)DeviceDisplay.MainDisplayInfo.Density;

        private readonly IHomePageViewModel viewModel;

        public HomePage(IHomePageViewModel homePageViewModel)
        {
            InitializeComponent();
            BindingContext = viewModel = homePageViewModel;

            SizeChanged += HomePageSizeChanged;
        }

        private void HomePageSizeChanged(object sender, EventArgs e)
        {
            backgroundImage.HeightRequest = Height * 0.5d;
            whiteBoxView.HeightRequest = collectionView.Height + whiteBoxView.CornerRadius.BottomLeft;
            whiteBoxView.TranslationY = defaultWhiteBoxViewOffset - verticalOffset < 0 ? 0 : defaultWhiteBoxViewOffset - verticalOffset;
            textStack.Margin = new Thickness(24, defaultWhiteBoxViewOffset - textStack.HeightRequest - 10, 0, 0);

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
    }
}
