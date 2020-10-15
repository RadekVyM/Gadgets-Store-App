using GadgetStoreApp.Core;
using Microsoft.Extensions.DependencyInjection;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.IO;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GadgetStoreApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        double verticalOffset = 0;
        double defaultWhiteBoxViewOffset => backgroundImage.HeightRequest - whiteBoxView.CornerRadius.TopLeft - appBarGrid.Height - StatusBar.Height;
        float density => (float)DeviceDisplay.MainDisplayInfo.Density;

        public string BackgroundImageName { get; set; }
        public string LogoImageName { get; set; }

        public HomePage()
        {
            BackgroundImageName = "background.jpg";
            LogoImageName = "logo.png";

            InitializeComponent();

            SizeChanged += HomePageSizeChanged;

            BindingContext = ((App)App.Current).ServiceProvider.GetRequiredService<IHomePageViewModel>();
        }

        #region Private methods

        private void HomePageSizeChanged(object sender, EventArgs e)
        {
            backgroundImage.HeightRequest = Height * 0.5d;
            whiteBoxView.HeightRequest = collectionView.Height + whiteBoxView.CornerRadius.BottomLeft;
            whiteBoxView.TranslationY = defaultWhiteBoxViewOffset - verticalOffset;
            textStack.Margin = new Thickness(24, defaultWhiteBoxViewOffset - textStack.HeightRequest - 10, 0, 0);
            gradientCanvasView.TranslationY = whiteBoxView.TranslationY + appBarGrid.Height;
            gradientCanvasView.HeightRequest = whiteBoxView.CornerRadius.TopLeft;
            imageOverlayCanvasView.HeightRequest = whiteBoxView.CornerRadius.TopLeft;

            UpdateTextOpacities();
        }

        private void CollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            verticalOffset = e.VerticalOffset;

            //System.Diagnostics.Debug.WriteLine(verticalOffset);

            double offset = defaultWhiteBoxViewOffset - verticalOffset < 0 ? 0 : defaultWhiteBoxViewOffset - verticalOffset;
            whiteBoxView.TranslationY = offset;
            gradientCanvasView.TranslationY = whiteBoxView.TranslationY + appBarGrid.Height;

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

        #region CanvasViews methods

        private void GradientCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var info = e.Info;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;

                paint.Shader = SKShader.CreateLinearGradient(
                                new SKPoint(info.Rect.Left, info.Rect.Top),
                                new SKPoint(info.Rect.Left, info.Height),
                                new SKColor[] { Color.White.ToSKColor().WithAlpha((byte)(1 * byte.MaxValue)), Color.White.ToSKColor().WithAlpha((byte)(0 * byte.MaxValue)) },
                                new float[] { 0.2f, 1f },
                                SKShaderTileMode.Clamp);

                canvas.DrawRoundRect(0, 0, info.Width, info.Height * 2, (float)(40 * Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density), (float)(40 * Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density), paint);
            }
        }

        private void LeftGradientPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var info = e.Info;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;

                paint.Shader = SKShader.CreateLinearGradient(
                                new SKPoint(info.Rect.Left, info.Rect.Top),
                                new SKPoint(info.Rect.Right, info.Rect.Top),
                                new SKColor[] { Color.White.ToSKColor().WithAlpha((byte)(1 * byte.MaxValue)), Color.White.ToSKColor().WithAlpha((byte)(0 * byte.MaxValue)) },
                                new float[] { 0.2f, 1f },
                                SKShaderTileMode.Clamp);

                canvas.DrawRect(0, 0, info.Width, info.Height, paint);
            }
        }

        private void RightGradientPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var info = e.Info;

            canvas.Clear();

            using (SKPaint paint = new SKPaint())
            {
                paint.IsAntialias = true;

                paint.Shader = SKShader.CreateLinearGradient(
                                new SKPoint(info.Rect.Right, info.Rect.Top),
                                new SKPoint(info.Rect.Left, info.Rect.Top),
                                new SKColor[] { Color.White.ToSKColor().WithAlpha((byte)(1 * byte.MaxValue)), Color.White.ToSKColor().WithAlpha((byte)(0 * byte.MaxValue)) },
                                new float[] { 0.2f, 1f },
                                SKShaderTileMode.Clamp);

                canvas.DrawRect(0, 0, info.Width, info.Height, paint);
            }
        }

        private void ImageOverlayPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            // I have to fill empty corners of whiteBoxView to hide gradient views when I take a screenshot.
            // If I do not do that and the main CollectionView is scrolled down (whiteBoxView.TranslationY == 0), gradient views and popular items will be visible on screenshot – they are not clipped by Frame on screenshot.

            var canvas = e.Surface.Canvas;
            var info = e.Info;

            SKBitmap bitmap;

            Assembly assembly = GetType().GetTypeInfo().Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("GadgetStoreApp.Images." + BackgroundImageName))
            {
                bitmap = SKBitmap.Decode(stream);
            }

            canvas.ClipRoundRect(new SKRoundRect(new SKRect(0, 0, info.Width, info.Height * 2), (float)whiteBoxView.CornerRadius.TopLeft * density, (float)whiteBoxView.CornerRadius.TopLeft * density), antialias: true, operation: SKClipOperation.Difference);

            float scale = Math.Max((float)info.Width / bitmap.Width, (float)(backgroundImage.Height * density) / bitmap.Height);

            float width = bitmap.Width * scale;
            float height = bitmap.Height * scale;

            var rect = new SKRect(
                Math.Abs(info.Width - width) / -2,
                (float)((Math.Abs(info.Height - height) / -2) + (appBarGrid.Height * density) + (StatusBar.Height * density)),
                info.Width + (Math.Abs(info.Width - width) / 2),
                (float)(info.Height + (Math.Abs(info.Height - height) / 2) + (appBarGrid.Height * density) + (StatusBar.Height * density)));

            canvas.DrawBitmap(bitmap, rect);

            bitmap.Dispose();
        }

        #endregion

        #endregion
    }
}