using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using Xamarin.Forms;

namespace GadgetStoreApp
{
    public class RatingView : SKCanvasView
    {
        public double Rating
        {
            get => (double)GetValue(RatingProperty);
            set => SetValue(RatingProperty, value);
        }

        public string Path
        {
            get => (string)GetValue(PathProperty);
            set => SetValue(PathProperty, value);
        }

        public object FrontColour
        {
            get => GetValue(FrontColourProperty);
            set => SetValue(FrontColourProperty, value);
        }

        public object BackColour
        {
            get => GetValue(BackColourProperty);
            set => SetValue(BackColourProperty, value);
        }

        public static readonly BindableProperty FrontColourProperty =
            BindableProperty.Create(nameof(FrontColour), typeof(object), typeof(RatingView), Color.Black, BindingMode.OneWay, propertyChanged: MyPropertyChanged);

        public static readonly BindableProperty BackColourProperty =
            BindableProperty.Create(nameof(BackColour), typeof(object), typeof(RatingView), Color.Black, BindingMode.OneWay, propertyChanged: MyPropertyChanged);

        public static readonly BindableProperty PathProperty =
            BindableProperty.Create(nameof(Path), typeof(string), typeof(RatingView), "", BindingMode.OneWay, propertyChanged: MyPropertyChanged);

        public static readonly BindableProperty RatingProperty =
            BindableProperty.Create(nameof(Rating), typeof(double), typeof(RatingView), 0d, BindingMode.OneWay, propertyChanged: MyPropertyChanged);

        private static void MyPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            RatingView view = bindable as RatingView;

            try
            {
                view.InvalidateSurface();
            }
            catch { };
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var info = e.Info;

            SKPath path = new SKPath();

            for(int i = 0; i < 5; i++)
                path.AddPath(SKPath.ParseSvgPathData(Path));

            using (SKPaint paint = new SKPaint())
            {
                paint.Style = SKPaintStyle.Fill;
                paint.Color = BackColour.GetColour().ToSKColor();
                paint.StrokeCap = SKStrokeCap.Round;
                paint.StrokeJoin = SKStrokeJoin.Round;
                paint.IsAntialias = true;

                path.GetBounds(out SKRect bounds);

                canvas.Translate(info.Width / 2, info.Height / 2);
                canvas.Scale(Math.Min(info.Width / bounds.Width, info.Height / bounds.Height));
                canvas.Translate(-bounds.MidX, -bounds.MidY);

                canvas.ClipPath(path);

                canvas.ResetMatrix();

                canvas.DrawRect(0, 0, info.Width, info.Height, paint);

                paint.Color = FrontColour.GetColour().ToSKColor();

                canvas.DrawRect(0, 0, (float)(info.Width * (Rating / 5f)), info.Height, paint);
            };
        }
    }
}
