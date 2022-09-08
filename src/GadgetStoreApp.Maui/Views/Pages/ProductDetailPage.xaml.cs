using GadgetStoreApp.Core;
using GadgetStoreApp.Maui.Extensions;
using GadgetStoreApp.Maui.Views.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace GadgetStoreApp.Maui.Views.Pages
{
    public partial class ProductDetailPage : ContentPage
    {
        private readonly IProductDetailPageViewModel viewModel;
        double imageCornerRadius => 24;
        double imageShadowMargin => 10;
        double imageHeight => imagesCollectionView.Height - (2 * imageShadowMargin);

        public string LogoImageName { get; set; }
        public double ImageWidth { get => Width / 2d; }
        public PathGeometry ImageClip { get; set; }


        public ProductDetailPage(IProductDetailPageViewModel productDetailPageViewModel)
        {
            InitializeComponent();
            BindingContext = viewModel = productDetailPageViewModel;

            SizeChanged += ProductDetailPageSizeChanged;
            imagesCollectionView.SizeChanged += ImagesCollectionViewSizeChanged;
        }


        private void ImagesCollectionViewSizeChanged(object sender, EventArgs e)
        {
            ImageClip = new PathGeometry
            {
                Figures = new PathFigureCollection
                {
                    new PathFigure
                    {
                        IsClosed = true, IsFilled = true, StartPoint = new Point(ImageWidth - imageCornerRadius, 0),
                        Segments = new PathSegmentCollection
                        {
                            new QuadraticBezierSegment(new Point(ImageWidth, 0), new Point(ImageWidth, imageCornerRadius)),
                            new LineSegment(new Point(ImageWidth, imageHeight - imageCornerRadius)),
                            new QuadraticBezierSegment(new Point(ImageWidth, imageHeight), new Point(ImageWidth - imageCornerRadius, imageHeight)),
                            new LineSegment(new Point(imageCornerRadius, imageHeight)),
                            new QuadraticBezierSegment(new Point(0, imageHeight), new Point(0, imageHeight - imageCornerRadius)),
                            new LineSegment(new Point(0, imageCornerRadius)),
                            new QuadraticBezierSegment(new Point(0, 0), new Point(imageCornerRadius, 0))
                        }
                    }
                }
            };

            OnPropertyChanged(nameof(ImageClip));
        }

        private void ProductDetailPageSizeChanged(object sender, EventArgs e)
        {
            var insets = this.Window.GetSafeAreaInsets();

            rootGrid.Margin = new Thickness(0, insets.Top + AppBar.AppBarPadding.Top, 0, 0);
            imagesRootGrid.Margin = new Thickness(insets.Left, 0, insets.Right, 0);
            specsRootGrid.Margin = new Thickness(insets.Left, 0, insets.Right, insets.Bottom);

            OnPropertyChanged(nameof(ImageWidth));
        }

        private void ImagesCollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            indicatorView.MoveTo(e.CenterItemIndex - 1);
        }

        private async void AddToCartTapped(object sender, EventArgs e)
        {
            addToCartButtonOverlay.Opacity = 0;

            await addToCartButtonOverlay.FadeTo(0.8d, 100);
            await addToCartButtonOverlay.FadeTo(0, 100);

            addToCartButtonOverlay.Opacity = 0;
        }

        private void FavoriteButtonClicked(object sender, EventArgs e)
        {
            viewModel.FavoriteCommand?.Execute(null);
        }

        private void CartButtonClicked(object sender, EventArgs e)
        {
            viewModel.GoToCartCommand?.Execute(null);
        }

        private async void AddToCartButtonClicked(object sender, EventArgs e)
        {
            viewModel.AddToCartCommand?.Execute(viewModel.Product);

            addToCartButtonOverlay.Opacity = 0;

            await addToCartButtonOverlay.FadeTo(0.8d, 100);
            await addToCartButtonOverlay.FadeTo(0, 100);

            addToCartButtonOverlay.Opacity = 0;
        }
    }
}
