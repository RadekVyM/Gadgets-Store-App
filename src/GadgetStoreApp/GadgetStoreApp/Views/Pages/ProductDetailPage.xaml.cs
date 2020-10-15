using GadgetStoreApp.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using Xamarin.Forms.Xaml;

namespace GadgetStoreApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        double imageCornerRadius => 24;
        double imageShadowMargin => 10;
        double imageHeight => imagesCollectionView.Height - (2 * imageShadowMargin);

        public string LogoImageName { get; set; }
        public double ImageWidth { get => Width / 2d; }
        public PathGeometry ImageClip { get; set; }

        public ProductDetailPage()
        {
            LogoImageName = "logo.png";

            InitializeComponent();

            BindingContext = ((App)App.Current).ServiceProvider.GetRequiredService<IProductDetailPageViewModel>();

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
    }
}